using System;
using System.Linq;
using System.Text;
using LimestoneDigital.NumberMetamorphoses.Contracts;

namespace LimestoneDigital.NumberMetamorphoses
{
    public class ValueTransformer : IValueTransformer
    {

        public string Transform(string value)
        {
            string result = "";
            if (IsDigital(value))
            {
                char[] numbers = value.ToCharArray();
                numbers = numbers.Distinct().ToArray();
                Array.Sort(numbers);

                int[] numbersInt = numbers.Select(obj => Convert.ToInt32(obj.ToString())).ToArray();

                int countOfSimvol = 0;
                int startIndex = numbersInt[0];


                if (numbersInt.Length > 1)
                {
                    result += startIndex;
                    for (int number = 0; number < numbersInt.Length - 1; number++)
                    {

                        if ((numbersInt[number] + 2 <= numbersInt[number + 1]))
                        {
                            if (countOfSimvol != 0)
                            {
                                countOfSimvol = 0;
                                result += "-" + numbersInt[number] + ", " + numbersInt[number + 1];
                            }
                            else
                            {
                                if (numbersInt[0] == numbersInt[number])
                                    result += ", " + numbersInt[number + 1];
                            }

                        }
                        if (numbersInt[number + 1] == numbersInt[numbersInt.Length - 1])
                        {
                            if (countOfSimvol > 0)
                                result += "-" + numbersInt[number + 1];
                        }
                        countOfSimvol++;
                    }
                }

            }

            return result;
        }


        public bool IsDigital(string letters)
        {

            foreach (char number in letters)
            {
               
                    if (number == '0' || number > '7')
                    {

                        throw new ArgumentOutOfRangeException();
                    }

                    if (number < '0' || number > '9' || number.ToString() == "")
                    {
                        throw new ArgumentException();
                    }
                    if (string.IsNullOrEmpty(number.ToString()))
                    {
                        throw new ArgumentNullException();
                    }
            }

            return true;
        }
    }
}

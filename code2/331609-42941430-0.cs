    namespace RomansTranslator
    {
        using System;
        using System.Collections.Generic;
        /// <summary>
        /// Accepts a number (between 1 and 3000) and prints its Roman equivalent.
        /// </summary>
        class Program
        {
            static void Main(string[] args)
            {
                string number = string.Empty;
                Console.Write("Enter the Numeric number : ");
                number = Console.ReadLine();
                if (IsValid(number)) // Validates the input
                {
                    string roman = ConvertToRoman(number);
                    Console.WriteLine("Roman Number is " + roman);
                }
                else
                {
                    Console.WriteLine("Invalid Number");
                }
                Console.ReadKey();
            }
    
            private static string ConvertToRoman(string numberString)
            {
                string romanValue = string.Empty;
                int number = Convert.ToInt32(numberString);
                if (number >= 1)
                {
                    // Loop through each roman character from highest 
                    foreach (int item in RomanDictionary().Keys)
                    {
                        while (number >= item)
                        {
                            romanValue = romanValue + RomanString(item);
                            number -= item;
                        }
                    }
                }
                return romanValue;
            }
    
            /// <summary>
            /// Returns Roman Equvalent
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            private static string RomanString(int n)
            {
                string romanString = string.Empty;
                romanString = RomanDictionary()[n].ToString();
                return romanString;
            }
    
            /// <summary>
            /// List of Roman Characters 
            /// </summary>
            /// <returns></returns>
            private static Dictionary<int, string> RomanDictionary()
            {
    
                Dictionary<int, string> romanDic = new Dictionary<int, string>();
                romanDic.Add(1000, "M");
                romanDic.Add(900, "CM");
                romanDic.Add(500, "D");
                romanDic.Add(400, "CD");
                romanDic.Add(100, "C");
                romanDic.Add(90, "XC");
                romanDic.Add(50, "L");
                romanDic.Add(40, "XL");
                romanDic.Add(10, "X");
                romanDic.Add(9, "IX");
                romanDic.Add(5, "V");
                romanDic.Add(4, "IV");
                romanDic.Add(1, "I");
                return romanDic;
            }
    
    
            /// <summary>
            /// Validates the Input
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            private static bool IsValid(string input)
            {
                int value = 0;
                bool isValid = false;
                if (int.TryParse(input, out value))
                {
                    if (value <= 3000)
                    {
                        isValid = true;
                    }
                }
                return isValid;
            }
        }
    }

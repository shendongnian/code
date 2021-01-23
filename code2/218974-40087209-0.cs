        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Globalization;
        using System.Linq;
        namespace ConvertStringDecimal
        {
            class Program
            {
                static void Main(string[] args)
                {
                    while(true)
                    {
                        // reads input number from keyboard
                        string input = Console.ReadLine();
                        double result = 0;
                        // remove empty spaces
                        input = input.Replace(" ", "");
                        // checks if the string is empty
                        if (string.IsNullOrEmpty(input) == false)
                        {
                            // check if input has , and . for thousands separator and decimal place
                            if (input.Contains(",") && input.Contains("."))
                            {
                                // find the decimal separator, might be , or .
                                int decimalpos = input.LastIndexOf(',') > input.LastIndexOf('.') ? input.LastIndexOf(',') : input.LastIndexOf('.');
                                // uses | as a temporary decimal separator
                                input = input.Substring(0, decimalpos) + "|" + input.Substring(decimalpos + 1);
                                // formats the output removing the , and . and replacing the temporary | with .
                                input = input.Replace(".", "").Replace(",", "").Replace("|", ".");
                            }
                            // replaces , with .
                            if (input.Contains(","))
                            {
                                input = input.Replace(',', '.');
                            }
                            // checks if the input number has thousands separator and no decimal places
                            if(input.Count(item => item == '.') > 1)
                            {
                                input = input.Replace(".", "");
                            }
                            // tries to convert input to double
                            if (double.TryParse(input, out result) == true)
                            {
                                result = Double.Parse(input, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
                            }
                        }
                        // outputs the result
                        Console.WriteLine(result.ToString());
                        Console.WriteLine("----------------");
                    }
                }
            }
        }

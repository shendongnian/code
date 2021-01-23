    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int iMonth = -1;
    
                // loop until iMonth is 0
                while (iMonth != 0)
                {
                    Console.WriteLine("Please insert a number from 1 to 12 and press enter. Enter 0 to exit.");
                    string sMonth = Console.ReadLine();
    
                    // try to get a number from the string
                    if (!int.TryParse(sMonth, out iMonth))
                    {
                        Console.WriteLine("You did not enter a number.");
                        iMonth = -1; // so we continue the loop
                        continue;
                    }
    
                    // exit the program
                    if (iMonth == 0) break;
    
                    // not a month
                    if (iMonth < 0 || iMonth > 12) {
                        Console.WriteLine("The number must be from 1 to 12.");
                        continue;
                    }
    
                    // get the name of the month in the language of the OS
                    string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(iMonth);
                    Console.WriteLine("The name of the month is " + monthName);
                }
    
            }
        }
    }

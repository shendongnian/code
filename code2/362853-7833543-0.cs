    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string result = MyRoundingFunction(1.01234567, 3);
                Console.WriteLine(result);
                result = MyRoundingFunction(1.01, 3);
                Console.WriteLine(result);
                Console.ReadLine();
            }
            public static string MyRoundingFunction(double value, int decimalPlaces)
            {
                string formatter = "{0:f" + decimalPlaces + "}";
                return string.Format(formatter, value);
            }
        }
    }

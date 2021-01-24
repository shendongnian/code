    using System;
    using System.Globalization;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                string test = "20..3";
                Console.WriteLine(double.TryParse(test, NumberStyles.Any, new CultureInfo("en-GB"), out _)); // false
                Console.WriteLine(double.TryParse(test, NumberStyles.Any, new CultureInfo("de-DE"), out _)); // true
            }
        }
    }

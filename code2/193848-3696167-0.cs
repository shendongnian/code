    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main(string[] args)
        {
            string text = "19,2";
            double value;
            bool valid = double.TryParse(text, NumberStyles.Float,
                                         CultureInfo.InvariantCulture,
                                         out value);
            Console.WriteLine(valid); // Prints false
        }
    }

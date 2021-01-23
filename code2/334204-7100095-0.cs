    using System;
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(150.757.TruncateWithDecimalPlaces(2));
            Console.WriteLine(150.747.TruncateWithDecimalPlaces(2));
            Console.Read();
        }
        public static double TruncateWithDecimalPlaces(this double input, int decimalPlaces)
        {
            double factor = Math.Pow(10, decimalPlaces);
            return Math.Truncate(input*factor)/factor;
        }
    }

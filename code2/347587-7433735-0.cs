        static void Main(string[] args)
        {
            Console.WriteLine(FormatDecimal(1.678M));
            Console.WriteLine(FormatDecimal(1.6M));
            Console.ReadLine();
        }
        private static string FormatDecimal(decimal input)
        {
            return Math.Abs(input - decimal.Parse(string.Format("{0:0.00}", input))) > 0 ?
                input.ToString() :
                string.Format("{0:0.00}", input);
        }

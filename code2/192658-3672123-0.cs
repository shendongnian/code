    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(ParseTime("04:00"));
            Console.WriteLine(ParseTime("0400"));
            Console.WriteLine(ParseTime("4:00"));
            Console.WriteLine(ParseTime("400"));
        }
        
        public static TimeSpan ParseTime(string input)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            DateTime parsedDateTime;
            if (!DateTime.TryParseExact(input, new [] { "HH:mm", "HHmm", "H:mm" }, cultureInfo, DateTimeStyles.None, out parsedDateTime))
            {
                int parsedInt32;
                
                if (!int.TryParse(input, NumberStyles.None, cultureInfo,  out parsedInt32))
                {
                    throw new ArgumentException("Unable to parse input value as time in any of the accepted formats.", "input");
                }
                int remainder;
                int quotient = Math.DivRem(parsedInt32, 100, out remainder);
                return new TimeSpan(quotient, remainder, 0);
            }
            return parsedDateTime.TimeOfDay;
        }
    }

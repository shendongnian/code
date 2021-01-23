    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            // Show the first 10 values
            foreach (string value in Counter("ABCD", 3).Take(10))
            {
                Console.WriteLine(value);
            }
        }
        
        public static IEnumerable<string> Counter(string digits, int digitCount)
        {
            long max = (long) Math.Pow(digits.Length, digitCount);
            for (long i = 0; i < max; i++)
            {
                yield return ConvertToString(i, digits, digitCount);
            }
        }
        
        public static string ConvertToString(long value,
                                             string digits,
                                             int digitCount)
        {
            char[] chars = new char[digitCount];
            for (int i = digitCount - 1 ; i >= 0; i--)
            {
                chars[i] = digits[(int)(value % digits.Length)];
                value = value / digits.Length;
            }
            return new string(chars);
        }
    }

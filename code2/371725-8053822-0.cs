    public static class StringExtensions
    {
        public static int Matches(this string text, string pattern)
        {
            int count = 0, i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
    }
    class Program
    {
        static void Main()
        {
            string s1 = "Sam's first name is Sam.";
            string s2 = "Dot Net Perls is about Dot Net";
            string s3 = "No duplicates here";
            string s4 = "aaaa";
    
            Console.WriteLine(s1.Matches("Sam"));  // 2
            Console.WriteLine(s1.Matches("cool")); // 0
            Console.WriteLine(s2.Matches("Dot"));  // 2
            Console.WriteLine(s2.Matches("Net"));  // 2
            Console.WriteLine(s3.Matches("here")); // 1
            Console.WriteLine(s3.Matches(" "));    // 2
            Console.WriteLine(s4.Matches("aa"));   // 2
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string str = "abcdefg";
            string substr = "cde";
            int index = IndexOf(str, substr);
            Console.WriteLine(index);
            Console.ReadLine();
        }
        private static int IndexOf(string str, string substr)
        {
            bool match;
            for (int i = 0; i < str.Length - substr.Length + 1; ++i)
            {
                match = true;
                for (int j = 0; j < substr.Length; ++j)
                {
                    if (str[i + j] != substr[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) return i;
            }
            return -1;
        }
    }

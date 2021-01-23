        static void Main(string[] args)
        {
            string result = string.Empty;
            ArrayList lines = GetLines("test.txt", "8394", true);
            foreach (string s in lines)
            {
                result += s;
            }
            Console.WriteLine(result);
        }

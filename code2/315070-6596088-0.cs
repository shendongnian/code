        static void Main(string[] args)
        {
            string result;
            ArrayList lines = GetLines("test.txt", "8394", true);
            foreach (string s in lines)
            {
                string result += s;
            }
            Console.WriteLine(result);
        }

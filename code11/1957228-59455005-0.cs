        static void Main(string[] args)
        {
            string input = "input";
            AddString(ref input);
            System.Console.WriteLine(input);
        }
        private static void AddString(ref string input)
        {
            input += "_edited";
        }

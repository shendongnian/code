        static void Main(string[] args)
        {
            var list = new List<string>{"W848","W998, W748","W953, W9484, W7373","W888"};
            Console.WriteLine("LINQ");
            list.ForEach(l => TestSplitRegexLinq(l));
            Console.WriteLine();
            Console.WriteLine("Loop");
            list.ForEach(l => TestSplitRegexLoop(l));
        }
        private static void TestSplitRegexLinq(string s)
        {
            string pattern = @"[W][0-9]*";                
            var reg = new Regex(pattern);
            reg.Matches(s).ToList().ForEach(m => Console.WriteLine(m.Value));
        }
        private static void TestSplitRegexLoop(string s)
        {
            string pattern = @"[W][0-9]*";                
            var reg = new Regex(pattern);
            foreach (Match m in reg.Matches(s))
            {
                Console.WriteLine(m.Value);
            }
        }

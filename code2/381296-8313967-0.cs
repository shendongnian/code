        static void Main(string[] args)
        {
            string S = "p1, p2, p3, p4, p5, p6";
            List<string> PatternList = new List<string>();
            PatternList.Add("p2");
            PatternList.Add("p5");
            PatternList.Add("p9");
            foreach (string s in PatternList.Where(x => !S.Contains(x)))
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }

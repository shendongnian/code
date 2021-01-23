    class Program
    {
        static void Main(string[] args)
        {
            string S = "12345asdfasdf12w3e412354w12341523142341235123";
            string patternString = "one1234554321asdf";
            MatchCollection p_ns = Regex.Matches(patternString, "one|12345|54321|asdf");
            var nonMatches = (from p_n in p_ns.Cast<Match>()
                              where !S.Contains(p_n.Value)
                              select p_n.Value);
            foreach (string nonMatch in nonMatches)
            {
                Console.WriteLine(nonMatch);
            }
            Console.ReadKey();
        }
    }

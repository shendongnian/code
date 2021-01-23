    class Program
    {
        static void Main(string[] args)
        {
            string S = "12345asdfasdf12w3e412354w12341523142341235123";
            string patternString = "one1234554321asdf";
            MatchCollection p_ns = Regex.Matches(patternString, "one|12345|54321|asdf");
            var nonMatches = p_ns.Cast<Match>().Where(s => !S.Contains(s.Value));
            foreach (Match nonMatch in nonMatches)
            {
                Console.WriteLine(nonMatch.Value);
            }
            
            Console.ReadKey();
        }
    }

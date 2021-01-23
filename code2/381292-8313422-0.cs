    class Program
    {
        static void Main(string[] args)
        {
            string S = "12345asdfasdf12w3e412354w12341523142341235123";
            string[] p_ns = { "one", "12345", "54321", "asdf" };
            var nonMatches = (from p_n in p_ns
                              where !S.Contains(p_n)
                              select p_n);
            foreach (string nonMatch in nonMatches)
            {
                Console.WriteLine(nonMatch);
            }
            Console.ReadKey();
        }
    }

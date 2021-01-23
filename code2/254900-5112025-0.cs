    using System;
    class Program
    {
        static string RemoveDashes(string s)
        {
            return string.Join("-", s.Split(new char[] { '-' }, 
                                StringSplitOptions.RemoveEmptyEntries));
        }
        static void Main(string[] args)
        {
            Tuple<string, string>[] tests = new Tuple<string,string> [] 
            {
                new Tuple<string, string> ("a--b-c-", "a-b-c"),
                new Tuple<string, string> ("-a--b-c-", "a-b-c"),
                new Tuple<string, string> ("--a--b--c--", "a-b-c"),
            };
            foreach (var t in tests)
            {
                string s = RemoveDashes(t.Item1);
                Console.WriteLine("{3}: {0} => Expected: {1}, Actual: {2}", 
                            t.Item1, t.Item2, s, s == t.Item2 ? "PASS" : "FAIL");
            }
        }
    }

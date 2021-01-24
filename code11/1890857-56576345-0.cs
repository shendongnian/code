    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> startsWithA = s => s[0] == 'a';
            List<string> listOfStrings = new List<string>()
            {
                "abc",
                "acb",
                "bac",
                "bca",
                "cab",
                "cba"
            };
            Dictionary<bool, List<string>> dictionaryOfListsOfStrings = listOfStrings.GroupBy(startsWithA).ToDictionary(x => x.Key, x => x.ToList());
        }
    }

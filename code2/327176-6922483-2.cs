    public static class RefData
    {
        private static readonly Dictionary<int, string> dict = BuildDictionary();
        private static Dictionary<int, string> BuildDictioary()
        {
            Dictionary<int, string> ret = new Dictionary<int, string>();
            ret.Add(0, "This Text");
            ret.Add(3, "That Text");
            ret.Add(4, "More Text");
            return ret;
        }
    }

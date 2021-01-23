    public static class StringExtension
    {
        public static bool ContainsWord(this string source, string contain)
        {
            List<string> sourceList = source.Split(' ').ToList();
            List<string> containList = contain.Split(' ').ToList();
            return sourceList.Intersect(containList).Any();
        }
    }
    string someText = "Stack Over Flow Community";
    var res = someText.ContainsWord("Over Stack");          // return true
    var res1 = someText.ContainsWord("Stack Community");    // return true
    var res2 = someText.ContainsWord("Stack1 Community");   // return false

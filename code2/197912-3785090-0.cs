    "elza7ma wa2fa fel matab".Split(' ')
                             .Intersect("2ana ba7eb el za7ma 2awy 2awy".Split(' '))
                             .Any();
    // as a string extension method
    public static class StringExtensions
    {
        public static bool OneWordMatches(this string theString, string otherString)
        {
            return theString.Split(' ').Intersect(otherString.Split(' ')).Any();
        }
    }
 
    // returns true
    "elza7ma wa2fa fel matab 2ana".OneWordMatches("2ana ba7eb el za7ma 2awy 2awy");

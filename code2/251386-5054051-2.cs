    // **** Start definition of the class bcdb_Globals ****
    public static class MyGlobals
    {
        static Dictionary<string, int> _month2Int = new Dictionary<string, int>
        {
            {"January", 1},
            {"February", 2},
            {"March", 3},
            {"April", 4},
            {"May", 5},
            {"June", 6},
            {"July", 7},
            {"August", 8},
            {"September", 9},
            {"October", 10},
            {"November", 11},
            {"December", 12}
        };
        static public int GetMonthAsInt(string month)
        {
            return( _month2Int[month] );
        }
    }
    public class MyClass
    {
        static char[] gDateSeparators = new char[2] { ',', ' ' };
        static Regex gDayRegex = new Regex("[0-9][0-9]?(st|nd|rd|th)");
        static Regex gMonthRegex = new Regex("January|February|March|April|May|June|July|August|September|October|November|December");
        static Regex gYearRegex = new Regex("[0-9]{4}");
        public void ParseMatchDate(string matchDate)
        {
            Stack matchDateTimes = new Stack();
            string[] tokens = matchDate.Split(gDateSeparators,StringSplitOptions.RemoveEmptyEntries);
            int curYear = int.MinValue;
            int curMonth = int.MinValue;
            int curDay = int.MinValue;
            for (int pos = tokens.Length-1; pos >= 0; --pos)
            {
                if (gYearRegex.IsMatch(tokens[pos]))
                {
                    curYear = int.Parse(tokens[pos]);
                }
                else if (gMonthRegex.IsMatch(tokens[pos]))
                {
                    curMonth = MyGlobals.GetMonthAsInt(tokens[pos]);
                }
                else if (gDayRegex.IsMatch(tokens[pos]))
                {
                    string tok = tokens[pos];
                    curDay = int.Parse(tok.Substring(0,(tok.Length-2)));
                    // Dates are in reverse order, so using a stack means we'll pull em off in the correct order
                    matchDateTimes.Push(new DateTime(curYear, curMonth, curDay));
                }
            }
            // Now get the datetimes
            while (matchDateTimes.Count > 0)
            {
                // Do something with dates here
            }
        }
}

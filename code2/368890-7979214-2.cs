        public static IEnumerable<String> GetRange(int startIndex, int endIndex)
        {
            List<string> rv = new List<string>();
            for (int i=startIndex+1;i<=endIndex;i++)
                rv.Add(System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(i));
            return rv;
        }

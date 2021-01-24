    public static class StringExtentions
    {
        public static IEnumerable<DateTime> ToDateTimePairs(this string input)
        {
            var dates = input.Split('-').Select(x => DateTime.Parse(x.Trim(), CultureInfo.GetCultureInfo("en-NZ"))).ToList();           
            
            if (dates[1].Hour < dates[0].Hour)
            {
                dates[1] = dates[1].AddDays(1);
            }
            return dates;
        }
    }

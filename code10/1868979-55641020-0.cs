    public static class DataTimeExt
    {
        public static IEnumerable<DateTime> TakeWhileInclusive(
            this DateTime value,
            Func<DateTime, bool> func)
        {
            DateTime dt = value;
    
            while (func(dt))
            {
                yield return dt;
                dt = dt.AddDays(1);
            }
    
            yield return dt;
        }
    }

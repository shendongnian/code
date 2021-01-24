    public static class DataTimeExt
    {
        public static IEnumerable<DateTime> TakeWhileInclusive(this DateTime value,
            Func<DateTime, bool> func)
        {
            DateTime dt = value;
                
            yield return dt; //[first            
            while (func(dt = dt.AddDays(1))) yield return dt; //in between            
            yield return dt; //last]
        }
    }

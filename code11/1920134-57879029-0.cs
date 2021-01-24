    static class DateTimeExtensionMethods
    {
        public static bool IsBetween(this DateTime source, TimeSpan lowerBound, TimeSpan upperBound)
        {
            return source >= source.Date.Add(lowerBound)
                && source <= source.Date.Add(upperBound);
        }
    }

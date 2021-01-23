    public static class Extensions
    {
        public static bool CompareWith(this DateTime dt1, DateTime dt2)
        {
            return
                dt1.Second == dt2.Second && // 1 of 60 match chance
                dt1.Minute == dt2.Minute && // 1 of 60 chance
                dt1.Day == dt2.Day &&       // 1 of 28-31 chance
                dt1.Hour == dt2.Hour &&     // 1 of 24 chance
                dt1.Month == dt2.Month &&   // 1 of 12 chance
                dt1.Year == dt2.Year;       // depends on dataset
        }
    }

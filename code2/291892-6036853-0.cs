    public static class MongoDateComparison
    {
        private static int precisionInMilliseconds = 1000;
        public static bool  MongoEquals(this DateTime dateTime, DateTime mongoDateTime)
        {
            return Math.Abs((dateTime - mongoDateTime).TotalMilliseconds) < precisionInMilliseconds;
        }
    }

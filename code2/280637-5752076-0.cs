    public static class Util
    {
        static long _id;
        public static string GetId()
        {
            return Next().ToString("0000000000000000");
        }
        private static long Next()
        {
            return Interlocked.Increment(ref _id);
        }
    }

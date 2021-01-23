    internal static class Assert 
    {
        [Conditional("DEBUG")]
        public static void IsNotNull<T>(T obj) where T : class
        {
            if (obj == null)
                System.Diagnostics.Debugger.Break();
        }
    }

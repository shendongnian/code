    namespace YourNameSpace
    {
        public static class Int32Extensions
        {
            public static string S(this int i)
            {
                return i == 1 ? "" : "s";
            }
        }
    }

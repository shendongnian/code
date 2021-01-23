    public static class IntExtensions
    {
        public static ToStringOrEmpty(this int value)
        {
            return value == 0 ? "" : value.ToString();
        }
    }

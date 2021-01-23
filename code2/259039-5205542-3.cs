    public static class ObjectExtensions
    {
        public static string GetString(this object o)
        {
            if (o == null)
            {
                return string.Empty;
            }
            return Convert.ToString(o);
        }
    }

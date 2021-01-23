    public static class Int32Extensions
    {
        public static Enum ToEnum(this Int32 obj)
        {
            return (Enum)((Object)(obj));
        }
    }
    public static class StringExtensions
    {
        public static Enum ToEnum(this Enum obj, String value)
        {
            return (Enum)Enum.Parse(obj.GetType(), value);
        }
    }

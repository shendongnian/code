    public static class EnumExtensions
    {
        public static Enum FromInt32(this Enum obj, Int32 value)
        {
            return (Enum)((Object)(value));
        }
        public static Enum FromString(this Enum obj, String value)
        {
            return (Enum)Enum.Parse(obj.GetType(), value);
        }
    }

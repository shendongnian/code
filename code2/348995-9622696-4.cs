    public static class FlagExtensions
    {
        public static TEnum AllFlags<TEnum>(this TEnum @enum)
            where TEnum : struct
        {
            Type enumType = typeof(TEnum);
            long newValue = 0;
            var enumValues = Enum.GetValues(enumType);
            foreach (var value in enumValues)
            {
                long v = (long)Convert.ChangeType(value, TypeCode.Int64);
                if(v == 1 || v % 2 == 0)
                {
                   newValue |= v; 
                }
            }
            return (TEnum)Enum.ToObject(enumType , newValue);
        }
    }

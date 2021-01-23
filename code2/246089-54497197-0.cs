    public static class EnumExtensions
    {
        public static TEnum DefinedCast<TEnum>(string value)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!MapByString<TEnum>.Instance.TryGetValue(value, out TEnum @enum))
            {
                throw new InvalidCastException(FormattableString.Invariant($"'{value}' is not a defined value"));
            }
            return @enum;
        }
        public static TEnum DefinedCast<TEnum>(int value)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!MapByInteger<TEnum>.Instance.TryGetValue(value, out TEnum @enum))
            {
                throw new InvalidCastException(FormattableString.Invariant($"'{value}' is not a defined value"));
            }
            return @enum;
        }
        private static class MapByInteger<TEnum>
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            public static readonly Dictionary<int, TEnum> Instance = ((TEnum[])Enum.GetValues(typeof(TEnum))).ToDictionary(e => (int)Convert.ChangeType(e, typeof(int), CultureInfo.InvariantCulture));
        }
        private static class MapByString<TEnum>
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            public static readonly Dictionary<string, TEnum> Instance = ((TEnum[])Enum.GetValues(typeof(TEnum))).ToDictionary(e => e.ToString(CultureInfo.InvariantCulture), StringComparer.OrdinalIgnoreCase);
        }
    }
 

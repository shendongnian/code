    public static class EnumHelper
    {
        public static T ConvertToEnum<T>(this string value)
        {
            if (Enum.IsDefined(typeof(T), value)) {
                return (T)Enum.Parse(typeof(T), value);
            }
            else {
                throw new ArgumentException($"{value} is not of the expected Enum");
            }
        }
        public static bool IsEnum<T>(this string value)
        {
            if (Enum.IsDefined(typeof(T), value)) {
                return true;
            }
            else {
                return false;
            }
        }
    }

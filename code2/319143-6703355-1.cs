    using System.ComponentModel;
    public enum StatusResult
    {
        [Description("Success")]
        Success,
        [Description("Failure...")]
        Failure
    }
    public static class AttributesHelperExtension
    {
        public static string ToDescription(this Enum value)
        {
            DescriptionAttribute[] da = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return da.Length > 0 ? da[0].Description : value.ToString();
        }
        public static T ToEnum<T>(this string stringValue, T defaultValue)
        {
            foreach (T enumValue in Enum.GetValues(typeof(T)))
            {
                DescriptionAttribute[] da = (DescriptionAttribute[])(typeof(T).GetField(enumValue.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (da.Length > 0 && da[0].Description == stringValue)
                    return enumValue;
            }
            return defaultValue;
        }
    }

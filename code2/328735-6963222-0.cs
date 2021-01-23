    public static class MyExtensionsClass
    {
        public static string ToDescriptionString<T>(this T val)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) 
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : string.Empty;
            }
        }
    }
    public enum LicenseTypes
    {
        [Description("DISCOUNT")]
        DISCOUNT,
        [Description("DISCOUNT EARLY-ADOPTER")]
        DISCOUNT_EARLY_ADOPTER,
        [Description("COMMERCIAL")]
        COMMERCIAL,
        [Description("COMMERCIAL EARLY-ADOPTER")]
        COMMERCIAL_EARLY_ADOPTER
    }

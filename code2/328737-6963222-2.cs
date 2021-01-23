    public static class MyExtensionsClass
    {
        public static string ToDescriptionString<T>(this T val)
            where T : struct, IConvertible
        {
            if (typeof(T).IsEnum) 
            {
               var type = val.GetType();
               var memInfo = type.GetMember(val.ToString());
               var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
               return ((DescriptionAttribute)attributes[0]).Description;
            }
            return ""; //all paths must return a value
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

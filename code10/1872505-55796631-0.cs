    public static class AttributeExtensions
    {
        public static string GetCategory<T>(this T val) where T: Enum
        {
            return GetAttr<CategoryAttribute, T>(val)?.Category ?? "";
        }
        public static string GetDescription<T>(this T val) where T : Enum
        {
            return GetAttr<DescriptionAttribute, T>(val)?.Description ?? "";
        }
        private static TAttr GetAttr<TAttr, T>(this T val) where TAttr : Attribute
        {
            return (TAttr)typeof(T)
                .GetField(val.ToString())
                ?.GetCustomAttributes(typeof(TAttr), false)
                ?.FirstOrDefault();
        }
    }

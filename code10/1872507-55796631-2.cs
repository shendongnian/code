    public static class AttributeExtensions
    {
        private class EnumMetadataCache<T> where T: Enum
        {
            private static readonly ConcurrentDictionary<T, (string category, string description)> MetadataCache = new ConcurrentDictionary<T, (string category, string description)>();
            public static (string category, string description) GetMetadata(T item)
            {
                return MetadataCache.GetOrAdd(item, val => (GetAttr<CategoryAttribute, T>(val)?.Category ?? "", GetAttr<DescriptionAttribute, T>(val)?.Description ?? ""));
            }
        }
        public static string GetCategory<T>(this T val) where T: Enum
        {
            return EnumMetadataCache<T>.GetMetadata(val).category;
        }
        public static string GetDescription<T>(this T val) where T : Enum
        {
            return EnumMetadataCache<T>.GetMetadata(val).description;
        }
        private static TAttr GetAttr<TAttr, T>(this T val) where TAttr : Attribute
        {
            return (TAttr)typeof(T)
                .GetField(val.ToString())
                ?.GetCustomAttributes(typeof(TAttr), false)
                ?.FirstOrDefault();
        }
    }

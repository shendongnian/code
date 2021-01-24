    public static class AttributeExtensions
    {
        private class EnumMetadata
        {
            public CategoryAttribute CategoryAttribute { get; set; }
            public DescriptionAttribute DescriptionAttribute { get; set; }
        }
        private class EnumMetadataCache<T> where T : Enum
        {
            private static readonly ConcurrentDictionary<T, EnumMetadata> MetadataCache = new ConcurrentDictionary<T, EnumMetadata>();
            public static EnumMetadata GetMetadata(T item)
            {
                return MetadataCache.GetOrAdd(item, val =>
                    new EnumMetadata
                    {
                        CategoryAttribute = GetAttr<CategoryAttribute, T>(val),
                        DescriptionAttribute = GetAttr<DescriptionAttribute, T>(val)
                    }
                );
            }
        }
        public static string GetCategory<T>(this T val) where T : Enum
        {
            return EnumMetadataCache<T>.GetMetadata(val).CategoryAttribute?.Category ?? "";
        }
        public static string GetDescription<T>(this T val) where T : Enum
        {
            return EnumMetadataCache<T>.GetMetadata(val).DescriptionAttribute?.Description ?? "";
        }
        private static TAttr GetAttr<TAttr, T>(this T val) where TAttr : Attribute
        {
            return (TAttr)typeof(T)
                .GetField(val.ToString())
                ?.GetCustomAttributes(typeof(TAttr), false)
                ?.FirstOrDefault();
        }
    }

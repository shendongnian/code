    public static class ObjectExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this object source)
            where TAttribute : Attribute
        {
            if (source != null)
            {
                object[] attributeSearchResult = source.GetType().GetCustomAttributes(typeof(TAttribute), true);
    
                if (attributeSearchResult.Length > 0)
                {
                    return (TAttribute)attributeSearchResult.Single();
                }
                else
                {
                    return default(TAttribute);
                }
            }
            else
            {
                return default(TAttribute);
            }
        }
    }

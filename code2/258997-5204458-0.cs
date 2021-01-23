    static class ExpandoExtensions
    {
        private static readonly ConditionalWeakTable<object, ExpandoObject> props =
            new ConditionalWeakTable<object, ExpandoObject>();
        public static dynamic Props(this object key)
        { 
            return props.GetOrCreateValue(key);       
        } 
    }

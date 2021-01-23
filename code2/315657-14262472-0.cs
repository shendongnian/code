    public static class ItExt
    {
        private static readonly Dictionary<Type, object> RegisteredConventions = new Dictionary<Type, object>();
        public static void RegisterConvention<T>(Func<T> convention)
        {
            RegisteredConventions.Add(typeof(T), convention);
        }
        public static T IsConventional<T>()
        {
            Func<T> conventionFunc = (Func<T>)RegisteredConventions[typeof(T)];
            return conventionFunc();
        }
    }

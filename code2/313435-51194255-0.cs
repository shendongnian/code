    public static class DefaultHelper
    {
        private delegate bool IsDefaultValueDelegate(object value);
        private static readonly ConcurrentDictionary<Type, IsDefaultValueDelegate> Delegates
            = new ConcurrentDictionary<Type, IsDefaultValueDelegate>();
        public static bool IsDefaultValue(this object value)
        {
            var type = value.GetType();
            var isDefaultDelegate = Delegates.GetOrAdd(type, CreateDelegate);
            return isDefaultDelegate(value);
        }
        private static IsDefaultValueDelegate CreateDelegate(Type type)
        {
            var parameter = Expression.Parameter(typeof(object));
            var expression = Expression.Equal(
                Expression.Convert(parameter, type),
                Expression.Default(type));
            return Expression.Lambda<IsDefaultValueDelegate>(expression, parameter).Compile();
        }
    }

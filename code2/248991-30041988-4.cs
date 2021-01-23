    public static class TypeExtensions
    {
        public static bool IsAssignableTo(this Type type, Type assignableType)
        {
            return assignableType.IsAssignableFrom(type);
        }
        public static bool IsAssignableTo<TAssignable>(this Type type)
        {
            return IsAssignableTo(type, typeof(TAssignable));
        }
    }

    public static class TypeHelpers
    {
        public static Boolean IsAssignableTo(Type type, Type assignableType)
        {
            return assignableType.IsAssignableFrom(type);
        }
        public static Boolean IsAssignableTo<TAssignable>(Type type)
        {
            return TypeHelpers.IsAssignableTo(type, typeof(TAssignable));
        }
    }
    public static class TypeExtensions
    {
        public static Boolean IsAssignableTo(this Type type, Type assignableType)
        {
            return TypeHelpers.IsAssignableTo(type, assignableType);
        }
        public static Boolean IsAssignableTo<TAssignable>(this Type type)
        {
            return TypeHelpers.IsAssignableTo<TAssignable>(type);
        }
    }

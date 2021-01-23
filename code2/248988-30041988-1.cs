    public static class TypeHelpers
    {
        public static Boolean IsAssignableTo(Type type, Type assignableType)
        {
            return assignableType.IsAssignableFrom(type);
        }
    }
    public static class TypeExtensions
    {
        public static Boolean IsAssignableTo(this Type type, Type assignableType)
        {
            return TypeHelpers.IsAssignableTo(type, assignableType);
        }
    }

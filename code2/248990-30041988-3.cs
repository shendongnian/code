    public static class TypeExtensions
    {
        public static bool IsAssignableTo(this Type type, Type assignableType)
        {
            return assignableType.IsAssignableFrom(type);
        }
    }

    public static class TypeExtensions
    {
        public static bool DirectlyImplements(this Type testType, Type interfaceType)
        {
            if (!interfaceType.IsInterface || !testType.IsClass || !interfaceType.IsAssignableFrom(testType)) { return false; }
            return !testType.GetInterfaces().Any(i => i != interfaceType && interfaceType.IsAssignableFrom(i));
        }
    }

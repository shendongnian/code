    public static class TypeExtensions
    {
        public static bool IsImplementing(this Type type, Type someInterface)
        {
            return type.GetInterfaces()
                 .Any(i => i == someInterface 
                     || i.IsGenericType 
                        && i.GetGenericTypeDefinition() == someInterface);
        }
    }

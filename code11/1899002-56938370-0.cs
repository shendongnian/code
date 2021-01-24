    public static class TypeExtensions
    {
        public static bool IsAssignableToType(this Type derivedType, Type baseType)
        {
            bool retVal = baseType.IsAssignableFrom(derivedType) ||
                          (baseType.IsGenericType && derivedType.IsAssignableToGenericType(baseType)) ||
                          (baseType.IsInterface && (Nullable.GetUnderlyingType(derivedType)?.IsAssignableToType(baseType) ?? false));
            return retVal;
        }
        private static bool IsAssignableToGenericType(this Type derivedType, Type genericBaseType)
        {
            var interfaceTypes = derivedType.GetInterfaces();
            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericBaseType)
                    return true;
            }
            if (derivedType.IsGenericType && derivedType.GetGenericTypeDefinition() == genericBaseType)
                return true;
            Type baseType = derivedType.BaseType;
            if (baseType == null) return false;
            return IsAssignableToGenericType(baseType, genericBaseType);
        }
    }

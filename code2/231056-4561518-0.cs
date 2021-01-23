    static bool IsDerivedFrom(Type type, Type genericBaseTypeDefinition) {
        if (!genericBaseTypeDefinition.IsGenericTypeDefinition) {
            throw new ArgumentException("genericBaseTypeDefinition");
        }
        Type baseType = type.BaseType;
        if (baseType == null) {
            return false;
        }
        if (baseType.IsGenericType) {
            Type generic = baseType.GetGenericTypeDefinition();
            if (generic == null) {
                return false;
            }
            return generic == genericBaseTypeDefinition;
        }
        return IsDerivedFrom(baseType, genericBaseTypeDefinition);
    }

    static bool IsDerivedFrom(Type type, Type genericBaseTypeDefinition) {
        Contract.Requires(type != null);
        Contract.Requires(genericBaseTypeDefinition != null);
        Contract.Requires(genericBaseTypeDefinition.IsGenericBaseTypeDefinition);
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

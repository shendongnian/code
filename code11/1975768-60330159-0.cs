        public static bool CheckConcreteTypeSatisfiesGenericParamConstraints(this Type concreteType, Type genericParamType)
        {
            bool hasReferenceTypeConstraint = genericParamType.GenericParameterAttributes.HasFlag(GenericParameterAttributes.ReferenceTypeConstraint);
            bool hasNewConstraint =
                genericParamType.GenericParameterAttributes.HasFlag(GenericParameterAttributes.DefaultConstructorConstraint);
            bool isNonNullable = genericParamType.GenericParameterAttributes.HasFlag(GenericParameterAttributes.NotNullableValueTypeConstraint);
            if (hasReferenceTypeConstraint)
            {
                if (concreteType.IsValueType)
                    return false;
            }
            else if (isNonNullable && !concreteType.IsValueType)
            {
                return true;
            }
            if (hasNewConstraint)
            {
                ConstructorInfo constrInfo = concreteType.GetConstructor(new Type[] { });
                if (constrInfo != null)
                    return false;
            }
            Type[] constraintTypes = genericParamType.GetGenericParameterConstraints();
            if (constraintTypes == null)
                return true;
            Type[] concreteTypeSuperTypes = concreteType.GetSelfSuperTypesAndInterfaces().Distinct().ToArray();
            foreach(Type constraintType in constraintTypes)
            {
                if (!concreteTypeSuperTypes.Contains(constraintType))
                {
                    return false;
                }
            }
            return true;
        }
        public static IEnumerable<Type> GetSelfSuperTypesAndInterfaces(this Type type)
        {
            if (type != null)
            {
                yield return type;
            }
            if (type.BaseType != null)
            {
                foreach (var superType in type.BaseType.GetSelfSuperTypesAndInterfaces())
                {
                    yield return superType;
                }
            }
            foreach (var interfaceType in type.GetInterfaces())
            {
                foreach (var superInterface in interfaceType.GetSelfSuperTypesAndInterfaces())
                {
                    yield return superInterface;
                }
            }
        }
        public class GenericParamInfo
        {
            public Type GenericParamType { get; }
            public Type ConcreteType { get; set; }
            public GenericParamInfo(Type genericParamType)
            {
                GenericParamType = genericParamType;
            }
        }
        // returns false if cannot resolve
        public static bool ResolveType
        (
            this Type argToResolveType, 
            Type genericArgType, 
            IEnumerable<GenericParamInfo> genericTypeParamsToConcretize)
        {
            if (genericArgType.IsGenericParameter)
            {
                GenericParamInfo foundParamInfo = genericTypeParamsToConcretize.Single(t => t.GenericParamType == genericArgType);
                if (!argToResolveType.CheckConcreteTypeSatisfiesGenericParamConstraints(foundParamInfo.GenericParamType))
                {
                    return false;
                }
                foundParamInfo.ConcreteType = argToResolveType;
                return true;
            }
            else if (genericArgType.IsGenericType)
            {
                var matchingSuperType =
                    argToResolveType.GetSelfSuperTypesAndInterfaces()
                                    .Distinct()
                                    .Where(arg => arg.IsGenericType)
                                    .Single(arg => arg.GetGenericTypeDefinition() == genericArgType.GetGenericTypeDefinition());
                if (matchingSuperType == null)
                    return false;
                Type[] concreteArgs = matchingSuperType.GetGenericArguments();
                Type[] genericArgs = genericArgType.GetGenericArguments();
                foreach((Type concrArgType, Type genArgType) in concreteArgs.Zip(genericArgs, (c, g) => (c, g)))
                {
                    if (!concrArgType.ResolveType(genArgType, genericTypeParamsToConcretize))
                        return false;
                }
                return true;
            }
            return true;
        }

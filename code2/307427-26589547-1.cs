    public class NonObsoleteConstructorFinder : IConstructorFinder
    {
	    private readonly DefaultConstructorFinder _defaultConstructorFinder = new DefaultConstructorFinder();
        public ConstructorInfo[] FindConstructors(Type targetType)
        {
            // Find all constructors using the default finder
            IEnumerable<ConstructorInfo> constructors = _defaultConstructorFinder.FindConstructors(targetType);
            // If this is a proxy, use the base type
            if (targetType.Implements<IProxyTargetAccessor>())
            {
                // It's a proxy. Check for attributes in base class.
                Type underlyingType = targetType.BaseType;
                List<ConstructorInfo> constructorList = new List<ConstructorInfo>();
                // Find matching base class constructors
                foreach (ConstructorInfo proxyConstructor in constructors)
                {
                    Type[] parameterTypes = proxyConstructor.GetParameters()
                                                            .Select(pi => pi.ParameterType)
                                                            .Skip(1)    // Ignore first parameter
                                                            .ToArray();
                    ConstructorInfo underlyingConstructor = underlyingType.GetConstructor(parameterTypes);
                    if (underlyingConstructor != null &&
                        !underlyingConstructor.HasAttribute<ObsoleteAttribute>())
                    {
                        constructorList.Add(proxyConstructor);
                    }
                }
                constructors = constructorList;
            }
            else
            {
                // It's not a proxy. Check for the attribute directly.
                constructors = constructors.Where(c => !c.HasAttribute<ObsoleteAttribute>());
            }
            return constructors.ToArray();
        }
    }

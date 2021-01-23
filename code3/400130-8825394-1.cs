    // Untested, beware of bugs
    var enumerationGenericType = enumeration.GetType().GetGenericArguments().FirstOrDefault();
    var resolverAttribute = enumerationGenericType.GetType().GetCustomAttributes(TypeOf(ProxyResolverAttribute)).FirstOrDefault();
    if (resolverAttribute != null) {
        var resolverType = resolverAttribute.ResolverType;
        // instanciate something of resolverType here
    }
     

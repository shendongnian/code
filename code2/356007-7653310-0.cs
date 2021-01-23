    public virtual object Resolve(Type requestedType, Session session = null, RequestContext requestContext = null)
    {
        ConstructorInfo constructor = requestedType.GetConstructors().First();
        object[] dependencies = null;
        Type resultType = requestedType;
        if (session == null || requestContext == null)
        {
            dependencies = constructor.GetParameters().Select(parameter => Resolve(parameter.ParameterType)).ToArray();
        }
        else
        {
            InitializeTestingArchitecture();
            var testVersion = _testingProvider.GetTestVersionFor(requestedType, requestContext, session);
            if(testVersion == null)
                return Resolve(requestedType);
            resultType = _testTypeLoader.LoadTypeForTestVersion(requestedType, testVersion);
            constructor = resultType.GetConstructors().First();
            dependencies = constructor.GetParameters().Select(parameter => Resolve(parameter.ParameterType, session, requestContext)).ToArray();
        }
        return Activator.CreateInstance(resultType, dependencies);
    }

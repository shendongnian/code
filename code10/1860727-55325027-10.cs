    /// <summary>
    /// Instanciates the specified <typeparamref name="TFunctionType"></typeparamref>.
    /// </summary>
    /// <typeparam name="TFunctionType"></typeparam>
    /// <param name="host"></param>
    /// <returns></returns>
    private static TFunctionType Instanciate<TFunctionType>(IHost host)
    {
        Type type = typeof(TFunctionType);
        // --> This part could be better...
        ConstructorInfo contructorInfo = type.GetConstructors().FirstOrDefault();
        ParameterInfo[] parametersInfo = contructorInfo.GetParameters();
        object[] parameters = LookupServiceInstances(host, parametersInfo);
        return (TFunctionType) Activator.CreateInstance(type, parameters);
    }
    /// <summary>
    /// Gets all the parameters instances from the host's services.
    /// </summary>
    /// <param name="host"></param>
    /// <param name="parametersInfo"></param>
    /// <returns></returns>
    private static object[] LookupServiceInstances(IHost host, IReadOnlyList<ParameterInfo> parametersInfo)
    {
        return parametersInfo.Select(p => host.Services.GetService(p.ParameterType))
                             .ToArray();
    }

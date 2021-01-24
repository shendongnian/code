    protected Task EnvGetJsonAsync<TReceive>(string endpointName, params object[] pathArgs)
    {
        return EnvGetJsonWithKeyAsync<TReceive>(endpointName, null, pathArgs);
    }
    protected Task EnvGetJsonWithKeyAsync<TReceive>(string endpointName, string key, params object[] pathArgs)
    {
        // your method here
    }

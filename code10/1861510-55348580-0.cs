    protected Task EnvGetJsonAsync<TReceive>(string endpointName, params object[] pathArgs)
    {
      // this is the original method. Here we just call the new one
      return EnvGetJsonoAsync<TReceive>(endpointName, null, pathArgs);
    }
    protected Task EnvGetJsonAsync<TReceive>(string endpointName, string id, params object[] pathArgs) 
    {
      .. the code implementation
    }

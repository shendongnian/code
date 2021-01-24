    protected Task EnvGetJsonAsync<TReceive>(string endpointName, params object[] pathArgs)
    {
     // Your Old Method
    }
    
    protected Task EnvGetJsonAsync<TReceive>(string endpointName, string id, params object[] pathArgs) 
    {
      // You new method
    }

    public TResponse GetResponse<TResponse>(Func<TResponse> responseFunction)
    {
        var result = default(TResponse);
        try
        {
            result = responseFunction();
        }
        catch (Exception e)
        {
            // SimpleTrace();  
            // SoapEnvelopeInterceptorTrace();                 
            // TimeWatch_PerformanceIEndpointBehaviorTrace();  
        }
        return result;
    }

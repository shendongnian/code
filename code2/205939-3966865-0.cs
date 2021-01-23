    public R Execute<T, R>(this T client, Func<R> serviceFunc) 
        where T : ICommunicationObject
        where L : ResponseBase
    {
        using (Tracer functionTracer = new Tracer(Constants.TraceLog))
        {
            try
            {
                R response = serviceFunc();
                if (response.ErrorCode != Constants.OK)
                {
                    ProxyCommon.ThrowError(response.ErrorCode);
                }
                return response;
            }
            finally
            {
                ProxyCommon.CloseWcfClient(client);
            }
        }
    }

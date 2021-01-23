    bool ServiceIsSupported(string serviceName)
    {
        return Services.ContainsKey(serviceName);
    }
    ServiceResult Process(string serviceName, ServiceTask task)
    {
        Service srv;
        if (Services.TryGetValue(serviceName, out srv))
        {
            return srv.Process(task);
        }
        else
        {
            // The service isn't supported.
            // Return a failure result
            return FailedServiceResult;
        }
    }

    bool DoesServiceExist(string serviceName, string machineName)
    {
        ServiceController[] services = ServiceController.GetServices(machineName);
        var service = services.FirstOrDefault(s => s.ServiceName == serviceName);
        return service != null;
    }

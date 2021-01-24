    public ServiceControllerStatus GetServiceStatus(string serviceName)
    {
        ServiceController[] services = ServiceController.GetServices();
        using (ServiceController service = services.FirstOrDefault(s => s.ServiceName == serviceName))
        {
            if (service != null)
            {
                using (ServiceController sc = new ServiceController(service.ServiceName))
                {
                    return sc.Status;
                }
            }
            else
            {
                //Here you can either throw an exception or return default(ServiceControllerStatus).
            }          
        }
    }

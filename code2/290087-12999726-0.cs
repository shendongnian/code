        // get the <system.serviceModel> / <services> config section
        ServicesSection services = ConfigurationManager.GetSection("system.serviceModel/services") as ServicesSection;
        // get all classs
        var allTypes = AppDomain.CurrentDomain.GetAssemblies().ToList().SelectMany(s => s.GetTypes()).Where(t => t.IsClass == true);
        // enumerate over each <service> node
        foreach (ServiceElement service in services.Services)
        {
            Type serviceType = allTypes.SingleOrDefault(t => t.FullName == service.Name);
            if (serviceType == null)
            {
                continue;
            }
            ServiceHost serviceHost = new ServiceHost(serviceType);
            serviceHost.Open();
        }

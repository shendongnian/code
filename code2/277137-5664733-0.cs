        ServiceController service = ServiceController.GetServices()
            .Where(s => s.ServiceName == "ServiceName")
            .SingleOrDefault();
        if (service != null)
        {
            service.Stop();
            service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(15));
            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(15));
        }
        else
        {
            // Couldn't find service
        }

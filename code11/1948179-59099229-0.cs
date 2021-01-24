      ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                if (service.ServiceName.Contains(serviceName))
                {
                    service.Start();
                }
            }

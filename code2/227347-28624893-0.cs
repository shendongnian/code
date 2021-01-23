            var service = new ServiceController(serviceInstaller.ServiceName);
            if (service.Status != ServiceControllerStatus.Running)
            {
                service.Start();
            }
        }

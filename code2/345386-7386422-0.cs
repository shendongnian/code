        private static bool IsServiceInstalled(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
                if (service.ServiceName == serviceName) return true;
            return false;
        }
        private static bool IsServiceInstalledAndRunning(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
                if (service.ServiceName == serviceName) return service.Status != ServiceControllerStatus.Stopped;
            return false;
        }

    public static void StopService(string serviceName, int timeoutMilliseconds)
    {
      ServiceController service = new ServiceController(serviceName);
      try
      {
        TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
    
        service.Stop();
        service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
      }
      catch
      {
        // ...
      }
    }

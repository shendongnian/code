    public class RunService
    {
     static int Main()(string[] args)
     {
      //TODO read serviceName and timeoutMilliseconds from args
      ServiceController service = new ServiceController(serviceName);
      try
      {
        int millisec1 = Environment.TickCount;
        TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
    
        service.Stop();
        service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
    
        // count the rest of the timeout
        int millisec2 = Environment.TickCount;
        timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2-millisec1));   service.Start();
    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
        // TODO return status code
      }
      catch
      { 
       // ...
      }
     }
    }

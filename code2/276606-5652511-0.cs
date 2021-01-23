    class Program
    {
        static void Main()
        {
            WindowsServiceManager service = new WindowsServiceManager();
            service.Run("W32Time", 2000);
            service.End("W32Time", 2000);
        }
    }
    
    public class WindowsServiceManager
    {
        internal void Run(string serviceId, int timeOut)
        {
            ServiceController s = new ServiceController(serviceId);
            TimeSpan t = TimeSpan.FromMilliseconds(timeOut);
    
            try
            {
                s.Start();
                s.WaitForStatus(ServiceControllerStatus.Running, t);
            }
            catch { throw; }
        }
    
        internal void End(string serviceId, int timeOut)
        {
            ServiceController s = new ServiceController(serviceId);
            TimeSpan t = TimeSpan.FromMilliseconds(timeOut);
            
            try
            {
                s.Stop();
                s.WaitForStatus(ServiceControllerStatus.Stopped, t);
            }
            catch { throw; }
     
    
           }
        }

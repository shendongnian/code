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
			using (ServiceController serviceController = new ServiceController(serviceId))
			{
				TimeSpan t = TimeSpan.FromMilliseconds(timeOut);
				serviceController.Start();
				serviceController.WaitForStatus(ServiceControllerStatus.Running, t);
			}
		}
		internal void End(string serviceId, int timeOut)
		{
			using (ServiceController serviceController = new ServiceController(serviceId))
			{
				TimeSpan t = TimeSpan.FromMilliseconds(timeOut);
				serviceController.Stop();
				serviceController.WaitForStatus(ServiceControllerStatus.Stopped, t);
			}
		}
	}

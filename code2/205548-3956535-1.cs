    using System.ServiceProcess;
    namespace WindowsService1
    {
      static class Program
      {
        static void Main()
        {
          ServiceBase[] ServicesToRun;
          ServicesToRun = new ServiceBase[] 
			    { 
				    new Service1() 
			    };
          ServiceBase.Run(ServicesToRun);
        }
      }
    }

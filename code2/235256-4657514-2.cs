    namespace WindowsService1
    {
        static class Program
        {
            static ServiceBase[] _servicesToRun;
    
            static void Main()
            {
                _servicesToRun = new ServiceBase[] 
    			{ 
    				new Service1() 
    			};
    
                string serviceName = _servicesToRun[0].ServiceName;
    
                ServiceBase.Run(_servicesToRun);
            }
        }
    }

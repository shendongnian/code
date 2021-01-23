    using System.ServiceProcess;
    using ServiceProcess.Helpers; //HERE
    
    namespace DemoService
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
    
    	    //ServiceBase.Run(ServicesToRun);
    	    ServicesToRun.LoadServices(); //AND HERE
    	}
        }
    }

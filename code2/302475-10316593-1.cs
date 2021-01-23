    namespace MyAppDomain
    {
        class Program
        {
   			static void Main(string[] args)
    		{
    			// Create an ordinary instance in the current AppDomain
    			Worker localWorker = new Worker();
    			localWorker.PrintDomain();
    
    			// Create a new application domain, create an instance 
    			// of Worker in the application domain, and execute code
    			// there.
    			AppDomain ad = AppDomain.CreateDomain("New domain");
    			ad.DomainUnload += ad_DomainUnload;
    			//ad.ExecuteAssembly("CustomSerialization.exe");
    
    			Worker remoteWorker = (Worker)ad.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, "MyAppDomain.Worker");
    
    			remoteWorker.PrintDomain();
    
    			AppDomain.Unload(ad);
    		}
    
    
    		static void ad_DomainUnload(object sender, EventArgs e) 
    		{ 
    			Console.WriteLine("unloaded, press Enter"); 
    		} 
    
    	}
    }
    	
    public class Worker : MarshalByRefObject
    {
    	public void PrintDomain()
    	{
    		Console.WriteLine("Object is executing in AppDomain \"{0}\"", AppDomain.CurrentDomain.FriendlyName);
    	}
    }

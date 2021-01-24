    [assembly: FunctionsStartup(typeof(Startup))]
    namespace FunctionApp2
    {
    	public class Startup : FunctionsStartup
    	{
    		public override void Configure(IFunctionsHostBuilder builder)
    		{
    			//builder.Services.AddSingleton<IClass1, Class1>();
    			
    		}
    	}
    
    }

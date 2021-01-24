    [assembly: FunctionsStartup(typeof(CustomBinding.Startup))]
    namespace CustomBinding
    {
        
        public class Startup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                Debug.WriteLine("FunctionsStartup.Configure");
            }        
        }   
    }

    public class AzureADOptionsSetup : IConfigureOptions<AzureADOptions> {
        private readonly IAzureADConfiguration service;
    
        public AzureADOptionsSetup(IAzureADConfiguration service) { 
            this.service = service;
        }
        
        public void Configure(AzureADOptions options) {
            service.Configure(options);
        }
    }

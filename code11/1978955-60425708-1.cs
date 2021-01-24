    public class CustomClass
    {
        private IConfiguration _configuration;
        public CustomClass(IConfiguration configuration) {
            _configuration = configuration;
      
        }
        public string getConnectString() {
        
            return  _configuration.GetValue<string>("ConnectionStrings:DefaultConnection"); ;
        }
    }

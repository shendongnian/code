    public class FilteringRequest
    {       
        private readonly IConfiguration _configuration;
        public FilteringRequest(IConfiguration configuration)
        {
            _configuration = configuration;
            Type = _configuration["Model:FilteringRequest:Type"];//set value from appsettings.json file
          
        }
     
        public string Type { get; set; } 
        // ...
    }

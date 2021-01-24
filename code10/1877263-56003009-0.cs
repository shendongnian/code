    //Appsetting
    "ApplicationConfigurations": {
        "SendSmsActive": "true"
      }
    //Controller
      public class HomeController : Controller
      {
            private readonly IConfiguration _configuration;
            public HomeController( IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public string GetConfig()
            {
                 string str = _configuration["ApplicationConfigurations:SendSmsActive"].ToString();
            }
      }

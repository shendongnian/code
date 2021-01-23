    class ConfigurationStorage{
          private static ConfigurationStorage _instance;
            
          // settng example - ConnectionString    
          public string ConnectionString {get;set;}
          public static ConfigurationStorage GetInstance(){
              return _instance ?? (_instance =  new ConfigurationStorage());
          }
    }

    //this will be injected
    public MyControllerCtor(IConfig cfg)
    
    public interface IConfig
    {
       string GetAppConfig(string key);
    }
    
    public class myConfig:IConfig
    {
       public string GetAppConfig(string key)
       {    
          //your logic
          var someVar = WebConfigurationManager.AppSettings["SomeProperty"];
          //your logic
          return yourCustomAppSetting;
       }
    }

    public class Service : System.Web.Services.WebService
    {
        AppController extractor;
        [WebMethod]
        public string HelloWorld()
        {
            extractor = new AppController();
            return AppController.staticString + " :: " + extractor.instanceString;
        }
    }
    class AppController
    {
        public static string staticString;
        public string instanceString;
        static AppController()
        {
            staticString = System.Configuration.ConfigurationManager.AppSettings["static"];
        }
        public AppController()
        {
            instanceString = System.Configuration.ConfigurationManager.AppSettings["instance"];
        }
    }

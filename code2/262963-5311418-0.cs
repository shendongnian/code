    public class WebService1 : System.Web.Services.WebService
    {
        public static int loadedFromDataBase;
        static WebService1()
        {
            loadedFromDataBase = ...
        }
        [WebMethod]
        public string HelloWorld()
        {
            return loadedFromDataBase.ToString();
        }
    }

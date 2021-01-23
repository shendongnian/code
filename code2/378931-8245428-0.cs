    [System.Web.Script.Services.ScriptService]
    public class ServerTime : System.Web.Services.WebService
    {
        [WebMethod]
        public string Get()
        {
            return System.DateTime.Now.ToLongTimeString();
        }
    }

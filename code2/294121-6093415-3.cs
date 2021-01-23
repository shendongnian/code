    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class DataService : System.Web.Services.WebService
    {
    
        [WebMethod(EnableSession = true)] //If you want?
        public bool Push(object someObject)
        {
            //var v = someObject as MyObjectClass;//Process object 
            return true;
        }
    }

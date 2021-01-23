    using System.Web.Services;
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService {
       [WebMethod]
       public int Status(int input) {
          return input + 1;
       }
    }

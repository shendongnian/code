    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [System.Web.Script.Services.ScriptService]
    [WebService(Namespace = "http://tempuri.org/")] // <-- Put something like: services.yourdomain.com in here.
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebService : System.Web.Services.WebService {
    
        [WebMethod]
        public int ValidateNameUpdateable(int input)
        {
            return input == 5 ? 22 : -1;
        }
    }

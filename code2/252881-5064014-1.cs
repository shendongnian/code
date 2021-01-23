    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Services;
    
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
    
        public WebService()
        {
    
    
        }
    
        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public string testGetParametersDynamic(string firstName, string lastName)
        {
            string fullName = firstName + lastName;
    
            return fullName;
        }
    
    }

    <%@ WebService Language="C#" Class="SampleService" %>
    using System;
    using System.Web;
    using System.Web.Services;
    using System.Xml;
    using System.Web.Services.Protocols;
    using System.Web.Script.Services;
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class SampleService: System.Web.Services.WebService
    {
        [WebMethod]
        public void TehMethod()
        {
            //do stuff server-side here
        }
    }
    

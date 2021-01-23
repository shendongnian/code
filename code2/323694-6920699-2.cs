    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TestService : TestInterface
    
        [WebInvoke(UriTemplate = "Test/{username}", Method = "GET", ResponseFormat = WebMessageFormat.Xml)]
        public string TestAsXML(string username)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
            return String.Format("Hello {0}!", String.IsNullOrWhiteSpace(username) ? "world" : username);
        }
    
        [WebInvoke(UriTemplate = "Test/{username}?format=json", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        public string TestAsJSON(string username)
        {
            // NOTE, if we GET this from a browsers, it will most likely have 
            // "Accept: text/html, application/xhtml+xml, */*" in the HTTP header
            // So the framework will return XML instead. Try from Fiddler2 instead or
            // write your own WCF client or from AJAX
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return String.Format("Hello {0}!", String.IsNullOrWhiteSpace(username) ? "world" : username);
        }

    <%@ WebHandler Language="C#" Class="Handler" %>
    
    using System;
    using System.Web;
    
    public class Handler : IHttpHandler {
    
        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "text/xml";
            Serializer.Serialize(obj, context.Response.Stream); //Write
        }
    
        public bool IsReusable {
            get {
                return false;
            }
        }
    }

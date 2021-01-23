    <%@ WebHandler Language="C#" Class="autocomplete" %>
    
    using System;
    using System.Web;
    using System.Web.Script.Serialization;
    
    public class autocomplete : IHttpHandler
    {
    
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/javascript";
            //load your terms from somewhere...
            string[] terms = {
                "ActionScript",
                "AppleScript",
                "Ruby",
                "Scala",
                "Scheme"
            };
            //convert the string array to Javascript
            context.Response.Write(new JavaScriptSerializer().Serialize(terms));
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

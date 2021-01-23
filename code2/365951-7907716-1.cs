    <%@ WebHandler Language="C#" Class="autocomplete" %>
    
    using System;
    using System.Web;
    using System.Web.Script.Serialization;
    using System.Linq;
    
    public class autocomplete : IHttpHandler
    {
    
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/javascript";
            
            //load your items from somewhere...
            string[] items =
            {
                "ActionScript",
                "AppleScript",
                "Ruby",
                "Scala",
                "Scheme"
            };
            
            //jQuery will pass in what you've typed in the search box in the "term" query string
            string term = context.Request.QueryString["term"];
    
            if (!String.IsNullOrEmpty(term))
            {
                //find any matches
                var result = items.Where(i => i.StartsWith(term, StringComparison.CurrentCultureIgnoreCase)).ToArray();
                //convert the string array to Javascript
                context.Response.Write(new JavaScriptSerializer().Serialize(result));
            }
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

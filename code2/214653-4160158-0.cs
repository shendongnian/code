    using System;
    using System.Web;
    public class InfinitContentHandler : IHttpHandler {
        private static Int32 counter = 1;
        
        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "text/plain";        
             
            for (int i = 1; i <= 10; i++) {
                context.Response.Write("<p><span>" + counter++ + "</span>");
                context.Response.Write("This is the dynamic content served freshly from server</p>");
            }
            
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    
    }

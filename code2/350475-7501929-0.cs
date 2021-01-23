    using System;
    using System.Web;
    // more here if you need them...
    
    namespace Namespace
    {    
        public class UserImageHandler : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
               // etc. etc.    
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }    
        }
    }

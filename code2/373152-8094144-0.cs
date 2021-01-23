    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace TestProject
    {
        /// <summary>
        /// Summary description for TestHandler1
        /// </summary>
        public class TestHandler1 : IHttpHandler
        {
    
            public void ProcessRequest(HttpContext context)
            {
                string id = context.Request["id"];
                context.Response.ContentType = "text/plain";
                context.Response.Write(id);
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

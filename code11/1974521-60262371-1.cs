    using System;
    using System.Collections.Generic;
    
    using System.Text;
    using System.Web;
    
    namespace ProvaIISdotNET
    {
        class myHandler : IHttpHandler
        {
            #region IHttpHandler Members
            public bool IsReusable
            {
                get { return true; }
            }
    
            public void ProcessRequest(HttpContext context)
            {
    
                context.Response.Write("<html><body>Hi everybody!</body></html>");
            }
    
            #endregion
        }
    
    }

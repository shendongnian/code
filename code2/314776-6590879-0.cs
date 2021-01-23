    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace YourNamespaceHere
    {
        using System;
        using System.Web; 
        using System.Collections;
    
        public class CrossOriginModule : IHttpModule {
            public String ModuleName {
                get { return "CrossOriginModule"; } 
            }    
        
            public void Init(HttpApplication application) {
                application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
            }
        
            private void Application_BeginRequest(Object source, EventArgs e) {
                HttpApplication application = (HttpApplication)source;
                HttpContext context = application.Context;
                CrossOriginHandler.SetAllowCrossSiteRequestOrigin(context);
            }
            
            public void Dispose() 
            {
            }
        }
       public class CrossOriginHandler : IHttpHandler
        {
            #region IHttpHandler Members
            public bool IsReusable
            {
                get { return true; }
            }
    
            public void ProcessRequest(HttpContext context)
            {
                //Clear the response (just in case)
                ClearResponse(context);
    
                //Checking the method
                switch (context.Request.HttpMethod.ToUpper())
                {
                    //Cross-Origin preflight request
                    case "OPTIONS":
                        //Set allowed method and headers
                        SetAllowCrossSiteRequestHeaders(context);
                        //Set allowed origin
                        //This happens for us with our module:
                        SetAllowCrossSiteRequestOrigin(context);
                        //End
                        context.Response.End();
                        break;
                    
                    default:
                        context.Response.Headers.Add("Allow", "OPTIONS");
                        context.Response.StatusCode = 405;
                        break;
                }
    
                context.ApplicationInstance.CompleteRequest();
            }
            #endregion
    
            #region Methods
            protected void ClearResponse(HttpContext context)
            {
                context.Response.ClearHeaders();
                context.Response.ClearContent();
                context.Response.Clear();
            }
    
            protected void SetNoCacheHeaders(HttpContext context)
            {
                context.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                context.Response.Cache.SetValidUntilExpires(false);
                context.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.Cache.SetNoStore();
            }
            #endregion
    
            public static void SetAllowCrossSiteRequestHeaders(HttpContext context)
            {
                string requestMethod = context.Request.Headers["Access-Control-Request-Method"];
    
                context.Response.AppendHeader("Access-Control-Allow-Methods", "GET,POST");
    
                //We allow any custom headers
                string requestHeaders = context.Request.Headers["Access-Control-Request-Headers"];
                if (!String.IsNullOrEmpty(requestHeaders))
                    context.Response.AppendHeader("Access-Control-Allow-Headers", requestHeaders);
            }
    
            public static void SetAllowCrossSiteRequestOrigin(HttpContext context)
            {
                string origin = context.Request.Headers["Origin"];
                if (!String.IsNullOrEmpty(origin))
                    context.Response.AppendHeader("Access-Control-Allow-Origin", origin);
                else
                    //This is necessary for Chrome/Safari actual request
                    context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            }
        }
    }

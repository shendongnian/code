     using System;
     using System.Web;
    
     namespace TT.Web.HttpModules
     {
          /// <summary>
          /// HttpModule to prevent caching 
          /// </summary>
          public class NoCacheModule : IHttpModule
          {
             public NoCacheModule()
             {
             }
     
             #region IHttpModule Members
     
             public void Init(HttpApplication context)
             {
                 context.EndRequest += (new EventHandler(this.Application_EndRequest));
             }
     
             public void Dispose()
             {
             }
     
             private void Application_EndRequest(Object source, EventArgs e) 
             {
                 HttpApplication application = (HttpApplication)source;
                 HttpContext context = application.Context;
                 context.Response.ExpiresAbsolute = DateTime.Now.AddDays( -100 );
                 context.Response.AddHeader( "pragma", "no-cache" );
                 context.Response.AddHeader( "cache-control", "private" );
                 context.Response.CacheControl = "no-cache";
             }
     
             #endregion
         }
     }

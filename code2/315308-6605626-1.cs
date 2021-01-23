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
                 context.Response.Cache.SetLastModified(DateTime.Now);
                 context.Response.Cache.SetExpires(DateTime.Now.AddMinutes(GetExpiryTime()));
                 context.Response.Cache.SetCacheability(HttpCacheability.Public);
                 context.Response.Cache.AppendCacheExtension("post-check=7200");
             //The pre-check is in seconds and the value configured in web.config is in minutes. So need to multiply it with 60
                 context.Response.Cache.AppendCacheExtension("pre-check=" + (GetExpiryTime() * 60).ToString());
                 context.Response.CacheControl = "public";
             }
     
             #endregion
         }
     }

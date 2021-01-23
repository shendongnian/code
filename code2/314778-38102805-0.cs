	using System;
	using System.Web;
	namespace NAMESPACE.HttpModules
	{
		public class CrossOriginModule : IHttpModule
		{
			public String ModuleName
			{
				get { return "CrossOriginModule"; }
			}
			public void Init(HttpApplication application)
			{
				application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
			}
			private void Application_BeginRequest(Object source, EventArgs e)
			{
				HttpApplication application = (HttpApplication)source;
				HttpContext context = application.Context;
				CrossOriginModule.ConfigureCORS(context);
			}
			public static void ConfigureCORS (HttpContext context)
			{
				//ORIGIN
				string origin = context.Request.Headers["Origin"];
				if (!String.IsNullOrEmpty(origin))
					context.Response.AppendHeader("Access-Control-Allow-Origin", origin);
				else
					context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
				//METHODS
				string requestMethod = context.Request.Headers["Access-Control-Request-Method"];
				context.Response.AppendHeader("Access-Control-Allow-Methods", "GET,POST");
				//CUSTOM HEADERS (we allow all)
				string requestHeaders = context.Request.Headers["Access-Control-Request-Headers"];
				if (!String.IsNullOrEmpty(requestHeaders))
					context.Response.AppendHeader("Access-Control-Allow-Headers", requestHeaders);
				//CREDENTIALS
				context.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
			}
			public void Dispose()
			{
			}
		}
	}

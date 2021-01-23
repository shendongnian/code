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
				string httpMethod = context.Request.HttpMethod.ToUpper();
				//preflight
				if (httpMethod == "OPTIONS")
				{
					ClearResponse(context);
					//Set allowed method and headers
					SetAllowCrossSiteRequestHeaders(context);
					//Set allowed origin
					SetAllowCrossSiteRequestOrigin(context);
					//end request
					context.ApplicationInstance.CompleteRequest();
				}
				else
				{
					SetAllowCrossSiteRequestOrigin(context);
				}
							
			}
			static void SetAllowCrossSiteRequestHeaders(HttpContext context)
			{
				string requestMethod = context.Request.Headers["Access-Control-Request-Method"];
				context.Response.AppendHeader("Access-Control-Allow-Methods", "GET,POST");
				//We allow any custom headers
				string requestHeaders = context.Request.Headers["Access-Control-Request-Headers"];
				if (!String.IsNullOrEmpty(requestHeaders))
					context.Response.AppendHeader("Access-Control-Allow-Headers", requestHeaders);
				//allow credentials
				context.Response.AppendHeader("Access-Control-Allow-Credentials", "true");
			}
			static void SetAllowCrossSiteRequestOrigin(HttpContext context)
			{
				string origin = context.Request.Headers["Origin"];
				if (!String.IsNullOrEmpty(origin))
					context.Response.AppendHeader("Access-Control-Allow-Origin", origin);
				else
					context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
			}
			static void ClearResponse(HttpContext context)
			{
				context.Response.ClearHeaders();
				context.Response.ClearContent();
				context.Response.Clear();
			}
			public void Dispose()
			{
			}
		}
		
	}

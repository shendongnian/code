    	//http://stackoverflow.com/questions/1160105/asp-net-mvc-disable-browser-cache
	//http://developer.yahoo.com/performance/rules.html#expires
	//http://ray.jez.net/prevent-client-side-caching-with-httpmodules/
	//http://stackoverflow.com/questions/2281919/expiry-silverlight-xap-file-from-browser-cache-programmatically
	public class XapFileHttpModule : IHttpModule
	{
		#region IHttpModule Members
	
		public void Init(HttpApplication context)
		{
			context.BeginRequest += context_BeginRequest;
		}
		
		public void Dispose()
		{
		}
	
		private void context_BeginRequest(Object source, EventArgs e) 
		{
			HttpApplication application = (HttpApplication)source;
			HttpContext context = application.Context;
			if(context.Request.FilePath.Contains(".xap"))
			{
				context.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
				context.Response.Cache.SetValidUntilExpires(false);
				context.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
				context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
				context.Response.Cache.SetNoStore(); 
			}
		}
	
		#endregion
	}

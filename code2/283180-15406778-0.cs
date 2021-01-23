	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	namespace SW
	{
		public class StopwatchAttribute : ActionFilterAttribute
		{
			public override void OnActionExecuting(ActionExecutingContext filterContext)
			{
				var stopwatch = new Stopwatch();
				filterContext.HttpContext.Items["Stopwatch"] = stopwatch;
				stopwatch.Start();
			}
			public override void OnResultExecuted(ResultExecutedContext filterContext)
			{
				var stopwatch = (Stopwatch)filterContext.HttpContext.Items["Stopwatch"];
				stopwatch.Stop();
				var httpContext = filterContext.HttpContext;
				var response = httpContext.Response;
				response.AddHeader("X-Runtime", stopwatch.Elapsed.TotalMilliseconds.ToString());
			}
		}
	}

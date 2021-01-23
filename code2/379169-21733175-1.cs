	public static class ActionRouteHelper
	{
		/// <summary>
		/// Given a controller/action selector, return its URL route
		/// </summary>
		/// <typeparam name="TController"></typeparam>
		/// <param name="url">helper extended</param>
		/// <param name="action">A lambda for choosing an action from the indicated controller.  May need to provide dummy method arguments.</param>
		/// <returns></returns>
		public static string RouteUrl<TController>(this UrlHelper url, Expression<Action<TController>> action) where TController : Controller
		{
			return url.RouteUrl(url.Route(action));
		}
		/// <summary>
		/// Given a controller/action selector, return its URL route
		/// </summary>
		/// <remarks>See inspiration from https://stackoverflow.com/a/8252301/1037948 </remarks>
		/// <typeparam name="TController">the controller class</typeparam>
		/// <param name="url">helper extended</param>
		/// <param name="action">A lambda for choosing an action from the indicated controller.  May need to provide dummy method arguments.</param>
		/// <returns></returns>
		public static RouteValueDictionary Route<TController>(this UrlHelper url, Expression<Action<TController>> action) where TController : Controller
		{
			// TODO: validate controller name for suffix, non-empty result, if that's important to you here rather than the link just not working
			var controllerName = typeof(TController).Name.Replace("Controller", string.Empty);
			// strip method name out of the expression, the lazy way (https://stackoverflow.com/questions/671968/retrieving-property-name-from-lambda-expression/17220748#17220748)
			var actionName = action.ToString(); // results in something like "c => c.MyAction(arg1,arg2)"
			var startOfMethodName = actionName.IndexOf('.')+1;
			var startOfArgList = actionName.IndexOf('(');
			actionName = actionName.Substring(startOfMethodName, startOfArgList - startOfMethodName);
			return new RouteValueDictionary {
				{ "Controller", controllerName },
				{ "Action", actionName }
			};
		}
	}

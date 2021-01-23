    public class Plugin : BasePlugin
    {
		public Plugin()
		{
		}
		/// <summary>
		/// Check to see if this plugin is installed
		/// </summary>
		public static bool IsInstalled(ITypeFinder typeFinder)
		{
			IEnumerable<Type> types = typeFinder.FindClassesOfType<IPluginFinder>(true);
			if (types.Count() == 1)
			{
				IPluginFinder plugins = Activator.CreateInstance(types.First()) as IPluginFinder;
				PluginDescriptor descriptor = plugins.GetPluginDescriptorBySystemName("MyPluginName");
				if (descriptor != null && descriptor.Installed)
				{
					return true;
				}
			}
			return false;
		}
    }
	/// <summary>
	/// Redirects to the 404 page if criteria not met
	/// </summary>
	public class FluffyTextureRequiredAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (Kitten.Texture != Textures.Fluffy)
			{
				var routeValues = new RouteValueDictionary();
				routeValues.Add("controller", "Common");
				routeValues.Add("action", "PageNotFound");
				filterContext.Result = new RedirectToRouteResult(routeValues);
			}
		}
	}
	/// <summary>
	/// Does application start event stuff for the plugin, e.g. registering
    /// global action filters
	/// </summary>
	public class StartupTask : IStartupTask
	{
		private ITypeFinder _typeFinder;
		public StartupTask()
		{
            //IStartupTask objects are created via Activator.CreateInstance with a parameterless constructor call, so dependencies must be manually resolved.
			_typeFinder = EngineContext.Current.Resolve<ITypeFinder>();
		}
		public void Execute()
		{
			// only execute if plugin is installed
			if (Plugin.IsInstalled(_typeFinder))
			{
                // GlobalFilters is in System.Web.Mvc
				GlobalFilters.Filters.Add(new FluffyTextureRequiredAttribute());
			}
		}
		public int Order
		{
			get { return int.MaxValue; }
		}
	}

    public class CreateContentTabsAttribute : ActionFilterAttribute
    {
    	public override void OnActionExecuted(ActionExecutedContext filterContext)
    	{
    		var result = filterContext.Result as ViewResultBase;
    		if (null == result) return;
    
    		var routeValues = filterContext.RouteData.Values;
    		var repository = ObjectFactory.GetInstance<ITabRepository>();
    		var context = filterContext.HttpContext;
    		var userName = context.User.Identity.Name; // Or get id from Membership.
    		var tabs = repository.ReadByUserId(userName);  
    
    		TabItemDisplay defaultTab = null;
    		var tabItems = new List<TabItemDisplay>();
    		foreach (var tab in tabs)
    		{
    			var tabItem = new TabItemDisplay 
    			{ 
    				Name = tab.Name,
    				Action = "View",
    				Controller = "Tab",
    				RouteValues = new { key = tab.Key }
    			};
    			tabItems.Add(tabItem);
    		}
    
    		if (context.Request.IsAuthenticated)
    		{
    			tabItems.Add(new TabItemDisplay
    			{
    				Name = "Account",
    				Action = "ChangePassword",
    				Controller = "Account",
    				RouteValues = new { siteKey = site.Key }
    			});
    		}
    
    		result.ViewData.TabItemsSet(tabItems);
    	}
    }

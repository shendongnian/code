    // used System.Reflection.Assembly.GetExecutingAssembly().GetName().Version to get the version then build the string you want
    
    context.MapRoute(
    				"Versioned_default",
    				"<YOURVERSIONSTRING>/{controller}/{action}/{id}",
    				new { action = "Index", controller = "Home", id = UrlParameter.Optional }
    			);

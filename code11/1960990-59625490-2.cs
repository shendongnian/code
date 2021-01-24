    linkGenerator.GetPathByAction(
    	nameof(HomeController.Index),
    	nameof(HomeController).Replace("Controller", string.Empty),
    	values: new { version = user.Version})
    };
	

    if (GetOrPost == "GET")
    {
    	if (actionName == "add" || actionName == "index" || actionName == "create" || actionName == "edit" || actionName == "delete" || actionName == "multiviewindex")
    	{
    	  ViewBag.Add = menuaccess.Any(i => i.MenuURL == controllerName && i.IsAdd);
    	  ViewBag.Read = menuaccess.Any(i => i.MenuURL == controllerName && i.IsRead);
    	  ViewBag.Create = menuaccess.Any(i => i.MenuURL == controllerName && i.IsCreate);
    	  // Any will be evaluated to true if any of item's MenuURL is equal to controllerName and IsUpdate set to true. false will be returned otherwise. Same explanation for others as well.
    	  ViewBag.Edit = menuaccess.Any(i => i.MenuURL == controllerName && i.IsUpdate);
    	  ViewBag.Delete = menuaccess.Any(i => i.MenuURL == controllerName && i.IsDelete);
    	}
    }

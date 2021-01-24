    protected override void OnActionExecuting(ActionExecutingContext context)
    {
    	base.OnActionExecuting(context);
    	try
    	{
    		//int roleid = int.Parse(Env.GetUserInfo("roleid"));
    		//int userid = int.Parse(Env.GetUserInfo("userid"));
    		string userid = User.Identity.GetUserId();
    		//string userid = Env.GetUserInfo("userid");
    		//string roleid = Env.GetUserInfo("roleid");
    		var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
    		// Select will return collection as opposed to scalar/single value. Pay attention to datatype here. 
    		IEnumerable<string> currentUserRoles = userManager.FindById(User.Identity.GetUserId()).Roles.Select(r => r.RoleId);
    		//string roleid = roles;
    		// @Sam: Added this variable
    		var actionNamesToCompare = new List<string>{"add", "index", "create", "edit", "delete", "multiviewindex"};
    		var descriptor = context.ActionDescriptor;
    		var actionName = descriptor.ActionName.ToLower();
    		var controllerName = descriptor.ControllerDescriptor.ControllerName.ToLower();
    		var controller = descriptor.ControllerDescriptor.ControllerName;
    
    		var GetOrPost = context.HttpContext.Request.HttpMethod.ToString();
    		var checkAreaName = context.HttpContext.Request.RequestContext.RouteData.DataTokens["area"];
    		string AreaName = "";
    		if (checkAreaName != null)
    		{
    			AreaName = checkAreaName.ToString().ToLower() + "/";
    		}
    
    		var cacheItemKey = "AllMenuBar";
    
    		var global = HttpRuntime.Cache.Get(cacheItemKey);
    
    		if (GetOrPost == "POST")
    		{
    			// Added index to string 02/03/2020
    			// Added add to actonName settings 02/08/2020
    			///if menupermission create,edit,delete then update value "true" in IsMenuChange file
    			if (controllerName == "menupermission" && actionNamesToCompare.Contains(actionName))
    			{
    				global = MenuBarCache(cacheItemKey, global, "shortcache");
    			}
    		}
    
    		if (global == null)//if cashe is null
    		{
    			global = MenuBarCache(cacheItemKey, global, "60mincache");//make cache from db
    		}
    
    
    		var menuaccess = (MenuOfRole[])global;
    		
    		if (GetOrPost == "GET")
    		{
    			if (actionNamesToCompare.Contains(actionName))
    			{
    				// Old Impementation May be removed at Cleanup if not used - 02/10/2020
    				//ViewBag.Add = menuaccess.Where(i => i.MenuURL == controllerName).Select(i => (i.IsAdd));
    				//ViewBag.Read = menuaccess.Where(i => i.MenuURL == controllerName).Select(i => (i.IsRead));
    				//ViewBag.Create = menuaccess.Where(i => i.MenuURL == controllerName).Select(i => (i.IsCreate));
    				//ViewBag.Edit = menuaccess.Where(i => i.MenuURL == controllerName).Select(i => (i.IsUpdate));
    				//ViewBag.Delete = menuaccess.Where(i => i.MenuURL == controllerName).Select(i => (i.IsDelete))();
    
    				// Stack Overflow corrections - 02/10/2020
    				ViewBag.Add = menuaccess.Any(i => i.MenuURL == controllerName && i.IsAdd);
    				ViewBag.Read = menuaccess.Any(i => i.MenuURL == controllerName && i.IsRead);
    				ViewBag.Create = menuaccess.Any(i => i.MenuURL == controllerName && i.IsCreate);                        
    				ViewBag.Edit = menuaccess.Any(i => i.MenuURL == controllerName && i.IsUpdate);
    				ViewBag.Delete = menuaccess.Any(i => i.MenuURL == controllerName && i.IsDelete);
    				ViewBag.Visable = menuaccess.Any(i => i.MenuURL == controllerName && i.IsVisable);
    			}
    		}
    		
    		// @sam: you can combine menuUrl evaluation like this using ternary operator.
    		var menuUrl = IsActionNameEqualToCrudPageName(actionName) ? AreaName + controllerName
    					  : AreaName + controllerName + "/" + actionName;
    
    		// var checkUrl = menuaccess.FirstOrDefault(i => (i.MenuURL == AreaName + controllerName + "/" + actionName) || i.MenuURL == menuUrl);
    		
    		// @sam: No need of this if statement
    		// var checkUrl = menuaccess.FirstOrDefault(i => (i.MenuURL == AreaName + controllerName + "/" + actionName) || i.MenuURL == menuUrl);
    		///checkUrl: check if menu url Exists in MenuPermission if not exists then will be run
    		/*if (checkUrl != null)
    		{
    			// Changed below line to use string instead of int..  01/26/2020
    			//var checkControllerActionRoleUserId = menuaccess.FirstOrDefault(i => i.MenuURL == menuUrl && String.IsNullOrEmpty(i.RoleId = roleid) && String.IsNullOrEmpty(i.UserId = userid));
    			// Added change to use roles as collection.
    			// @Sam: Since both if and else are doing same of operations, 
    			//       the below if-else can be comibined as follows:
    			
    			/*var checkControllerActionRoleUserId = menuaccess.FirstOrDefault(i => i.MenuURL == menuUrl  &&currentUserRoles.Contains(i.RoleId) && i.UserId == userid);
    			///check menu  && roleid && userid
    			if (checkControllerActionRoleUserId != null)
    			{
    				if (IsActionNameEqualToCrudPageName(actionName))
    				{
    					CheckAccessOfPageAction(context, actionName, checkControllerActionRoleUserId);
    				}
    				else
    				{
    				if (checkControllerActionRoleUserId.IsRead == false || checkControllerActionRoleUserId.IsDelete == false || checkControllerActionRoleUserId.IsCreate == false || checkControllerActionRoleUserId.IsUpdate == false)//if userid !=null && Check Crud
    					{
    						UnAuthoRedirect(context);
    
    					}
    				}
    			}
    			else
    			{
    				var checkControllerActionRole = menuaccess.FirstOrDefault(i => i.MenuURL == menuUrl && currentUserRoles.Contains(i.RoleId) && i.UserId == null);
    				if (checkControllerActionRole != null)
    				{
    
    					if (IsActionNameEqualToCrudPageName(actionName))
    					{
    						CheckAccessOfPageAction(context, actionName, checkControllerActionRole);
    					}
    					else
    					{
    						if (checkControllerActionRole.IsRead == false || checkControllerActionRole.IsDelete == false || checkControllerActionRole.IsCreate == false || checkControllerActionRole.IsUpdate == false)//if userid !=null && Check Crud
    						{
    							UnAuthoRedirect(context);
    						}
    					}
    				}
    				else
    				{
    					if (IsThisAjaxRequest() == false)//if userid !=null && Check Crud
    					{
    						UnAuthoRedirect(context);
    					}
    
    				}
    			}//
    		} */
    		var checkControllerActionRoleUserId = menuaccess.FirstOrDefault(i => i.MenuURL == menuUrl  &&currentUserRoles.Contains(i.RoleId) 
    		 && (i.UserId == userid || i.UserId == null) // @Sam: This is how we can combine
    		 );
    		///check menu  && roleid && userid
    		if (checkControllerActionRoleUserId != null)
    		{
    			if (IsActionNameEqualToCrudPageName(actionName))
    			{
    				CheckAccessOfPageAction(context, actionName, checkControllerActionRoleUserId);
    			}
    			else
    			{
    			if (checkControllerActionRoleUserId.IsRead == false || checkControllerActionRoleUserId.IsDelete == false || checkControllerActionRoleUserId.IsCreate == false || checkControllerActionRoleUserId.IsUpdate == false)//if userid !=null && Check Crud
    				{
    					UnAuthoRedirect(context);
    
    				}
    			}
    		}
    	}
    	catch (Exception)
    	{ }
    }

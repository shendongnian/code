        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewData["CurrentUser"] = CurrentUser; // this is a public property in the BaseController
            if (CurrentUser != null && CurrentUser.Account.Status != AccountStatus.Active)
            {
                // if the account is disabled and they are authenticated, we need to allow them
                // to get to the account settings screen where they can re-activate, as well as the logoff
                // action.  Everything else should be disabled.
                string[] actionWhiteList = new string[] { 
                    Url.Action("Edit", "AccountSettings", new { id = CurrentUser.Account.Id, section = "billing" }), 
                    Url.Action("Logoff", "Account")
                };
                
                var allowAccess = false;
                foreach (string url in actionWhiteList)
                {
                    // compare each of the whitelisted paths to the raw url from the Request context.
                    if (url == filterContext.HttpContext.Request.RawUrl)
                    {
                        allowAccess = true;
                        break;
                    }
                }
                if (!allowAccess)
                {
                    filterContext.Result = RedirectToAction("Edit", "AccountSettings", new { id = CurrentUser.Account.Id, section = "billing" });
                }
            }
            
            base.OnActionExecuting(filterContext);
        }

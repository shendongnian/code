    public class AccessControlAttribute : AuthorizeAttribute
    {
    	public bool AccessControlEnabled {
    		get { return AccessControlSection.Settings != null; }
    	}
    
    	public bool LockoutEnabled {
    		get { return AccessControlEnabled && AccessControlSection.Settings.ForceLockout != null && AccessControlSection.Settings.ForceLockout.Enabled; }
    	}
    
    	public AccessControlAttribute() {
    		if (LockoutEnabled) {
    			Roles = AccessControlSection.Settings.ForceLockout.AllowRoles;
    			Users = AccessControlSection.Settings.ForceLockout.AllowUsers;
    		}
    	}
    
    	protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
    		if (filterContext.IsChildAction || ApproveLockoutAction(filterContext))
    			return;
    
    		if (LockoutEnabled && !string.IsNullOrEmpty(AccessControlSection.Settings.ForceLockout.DefaultPage)) {
    			filterContext.HttpContext.Response.Redirect(AccessControlSection.Settings.ForceLockout.DefaultPage, false);
    			return;
    		}
    
    		base.HandleUnauthorizedRequest(filterContext);
    	}
    
    	private static bool ApproveLockoutAction(AuthorizationContext filterContext) {
    		var forceLockout = AccessControlSection.Settings.ForceLockout;
    		if (forceLockout == null || !forceLockout.Enabled)
    			return true;
    
    		if (string.IsNullOrEmpty(forceLockout.LogOnUrl) || string.IsNullOrEmpty(forceLockout.LogOffUrl))
    			return false;
    
    		if (filterContext.HttpContext.Request.AppRelativeCurrentExecutionFilePath.Equals(forceLockout.LogOnUrl, StringComparison.OrdinalIgnoreCase)
    			|| filterContext.HttpContext.Request.AppRelativeCurrentExecutionFilePath.Equals(forceLockout.LogOffUrl, StringComparison.OrdinalIgnoreCase)) {
    			return true;
    		}
    
    		return false;
    	}
    }

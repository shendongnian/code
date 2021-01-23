        public class UserAuthenticationModule : IHttpModule
        {
    	private HttpApplication _Context;
    	private RoleManagerModule _RoleManager;
    
    	public void Init(HttpApplication context)
    	{
    		_Context = context;
    		context.AuthenticateRequest += AuthenticateUser;
    		_RoleManager = (RoleManagerModule)context.Modules["RoleManager"];
    		_RoleManager.GetRoles += roleManager_GetRoles;
    	}
    
    	// http://stackoverflow.com/questions/1727960/how-to-keep-roleprovider-from-overriding-custom-roles
    	private void roleManager_GetRoles(object sender, RoleManagerEventArgs e)
    	{
    		if (_Context.User is UserPrincipal)
    			e.RolesPopulated = true; // allows roles set in AuthenticateUser to stick.
    	}
    
    	private static void AuthenticateUser(object sender, EventArgs e)
    	{
    		var app = (HttpApplication) sender;
    		if (app.Context == null) return;
    
    		var user = app.Context.User;
    
    		// not signed in, forms authentication module takes care of redirecting etc.
    		if (user == null) return;
    		// we're done then.
    		if (user is IUser) return;
    
    		var userEntity = IoC.Resolve<IUserRepository>().FindByUserName(user.Identity.Name);
    
    		// we can't find the user in the database.
    		if (userEntity == null)
    			throw new ApplicationException(string.Format("User \"{0}\" deleted from, or renamed in, database while logged into application.", 
    				user.Identity.Name));
    
    		// signed in, assigning user, which should assign Thread.CurrentPrincipal as well (it wouldn't do this on PostAuthenticateRequest).
    		app.Context.User = new UserPrincipal(userEntity);
    		userEntity.SetAuthenticated();
    	}
    
    	//Implement IDisposable.
    	public void Dispose()
    	{
    	}
        }

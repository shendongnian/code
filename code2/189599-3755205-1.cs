// Code that goes in the Global.asax.cs
// that runs after .Net has done it's authentication
protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
{
    IPrincipal user = HttpContext.Current.User;
    if (user == null) { return; }
    FormsIdentity formsIdentity = user.Identity as FormsIdentity;
    if (formsIdentity == null || !formsIdentity.IsAuthenticated) { return; }
    Principal principal = new Principal(new Identity(formsIdentity.Ticket));
    HttpContext.Current.User = principal;
    Thread.CurrentPrincipal = principal;
}
// Base implementation of the System.Security.Principal.IPrincipal interface.
public class Principal : System.Security.Principal.IPrincipal
{
	#region Fields
	private IIdentity _identity = null;
	#endregion
	#region Constructors
	public Principal(IIdentity identity)
	{
		_identity = identity;
	}
	#endregion
	#region Properties
	public IIdentity Identity
	{
		get
		{
			return _identity;
		}
	}
	#endregion
	#region Methods
	public bool IsInRole(string role)
	{
        return (_identity != null && _identity.IsAuthenticated);
	}
	#endregion
}
</code
// Base implementation of the System.Security.Principal.IIdentity interface. 
public class Identity : System.Security.Principal.IIdentity
{
	#region Fields
	private readonly int _userId;
	private readonly bool _isAuthenticated;
	private readonly string _userName;
	#endregion
	#region Constructors
	public Identity(FormsAuthenticationTicket formsAuthTicket)
	{
		if (formsAuthTicket == null)
		{
			throw new NullReferenceException("FormsAuthenticationTicket may not be null.");
		}
		if (string.IsNullOrEmpty(formsAuthTicket.UserData))
		{
			throw new NullReferenceException("FormsAuthenticationTicket.UserData may not be null or empty.");
		}
		string[] userData = formsAuthTicket.UserData.Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries);
		if (userData.Length &lt; 1)
		{
			throw new ArgumentOutOfRangeException("formsAuthTicket", userData, "UserData does not contain a UserId and or a SiteId");
		}
        _userId = Convert.ToInt32(userData[0]);
		_isAuthenticated = !formsAuthTicket.Expired;
		_userName = formsAuthTicket.Name;
	}
	#endregion
	#region Properties
	public int UserId
	{
		get
		{
			return _userId;
		}
	}
	public string AuthenticationType
	{
		get
		{
			return "Forms";
		}
	}
	public bool IsAuthenticated
	{
		get
		{
			return _isAuthenticated;
		}
	}
	public string Name
	{
		get
		{
			return _userName;
		}
	}
	#endregion
}

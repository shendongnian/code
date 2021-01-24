public class AuthorizedRoles : TypeFilterAttribute
{
	public AuthorizedRoles(params string[] authorizedRoles) : base(typeof(AuthorizationFilter))
	{
		Arguments = new object[] { authorizedRoles };
	}
	private class AuthorizationFilter: IActionFilter
	{
		private readonly ILogger _logger;
		private readonly string[] _authorizedRoles;
		public AuthorizationFilter(ILoggerFactory loggerFactory, string[] authorizedRoles)
		{
			_logger = loggerFactory.CreateLogger<AuthorizedRoles>();
			_authorizedRoles = authorizedRoles;
		}
		public void OnActionExecuting(ActionExecutingContext context)
		{
			string usersRoles = context.HttpContext.Request.Headers["BOEINGACCESSROLES"];
			if (!Authorization.IsAuthorized(usersRoles, _authorizedRoles))
			{
				context.Result = new ViewResult { ViewName = "NotAuthorized" };
			}
		}
		public void OnActionExecuted(ActionExecutedContext context)
		{
		}
	}
}
Note, that I don't know of a good way to pass ViewData information to a Razor page from within the Action Filter class, so when a user is not authorized a static "NotAuthorized" view is called from the `OnActionExecuting` method instead of setting `ViewData["Message"] = "Not Authorized"` and calling the "MyAppMessage" view.
A filter like this can now be used above the controller method (or above the entire controller class, if desired) to only allow access to users that have at least one of the specified roles:
[AuthorizedRoles("TYPE1_USER", "TYPE2_USER", "TYPE3_USER")]
public IActionResult Index()
{
    // Do stuff to complete the action requested here
    return View();
}

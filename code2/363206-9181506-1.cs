    public class DisplayIfAuthorizedAttribute : System.Web.Mvc.AuthorizeAttribute
	{
		private string _ViewNameIfNotAuthorized;
		public DisplayIfAuthorizedAttribute(string viewNameIfNotAuthorized = null)
		{
			_ViewNameIfNotAuthorized = viewNameIfNotAuthorized;
		}
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			bool isAuthorized = base.AuthorizeCore(filterContext.HttpContext);
			if (!isAuthorized)
			{
				filterContext.Result = GetFailedResult();
			}
		}
		private ActionResult GetFailedResult()
		{
			if (!String.IsNullOrEmpty(_ViewNameIfNotAuthorized))
			{
				return new ViewResult { ViewName = _ViewNameIfNotAuthorized };
			}
			else
				return new EmptyResult();
		}
	}

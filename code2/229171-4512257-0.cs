	public class TicketRequiredActionFilter : ActionFilterAttribute
	{
        private Type _ticketType;
		
		public TicketRequiredAttribute(Type ticketType)
		{
		      _ticketRequired = ticketType;     
		}
		
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
		   UserServices userServices = GetUserServicesViaDIContainer(); // you'll need to figure out how to implement this 
		   string userId = filterContext.HttpContext.User.Identity.Name
		   bool hasTicket = userServices.HasTicket(_ticketType, (int)userId); // again, you'll need to figure out the exact implementation
		   if(!hasTicket)
		   {
				filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, {"action", "NoPermission" } })
		   }		   
		}
	 }

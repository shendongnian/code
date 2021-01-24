public class UserAreaRegistration : AreaRegistration 
{
	public override string AreaName => "User";
	public override void RegisterArea(AreaRegistrationContext context)
	{
		context.MapRoute(
			name: "User",
			url: "User/{userId}/{controller}/{action}/{id}",
			defaults: new { action = "Index", id = UrlParameter.Optional }
		);
		context.MapRoute(
			"User_default",
			"User/{controller}/{action}/{id}",
			new {action = "Index", id = UrlParameter.Optional}
		);
	}
}
**Links**   
Instead of using `ActionLink` i am now using `RouteLink`.
@Html.RouteLink("KPIs", "User", new { Controller = "Kpi", Action = "Index", userId = Model.Id })

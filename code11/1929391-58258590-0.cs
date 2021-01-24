using System;
public class TrackMyChange : IActionFilter
{
	private readonly string _chengeMessage;
	private readonly IChangeLogRepository _changeLogRepository;
	public TrackMyChange(string changeMessage,IChangeLogRepository changeLogRepository)
	{
		this._changeLogRepository = changeLogRepository;
		this._chengeMessage = chengeMessage;
	}
	public void OnActionExecuting(ActionExecutingContext context)
	{
	// Do something before the action executes.
	}
	public void OnActionExecuted(ActionExecutedContext context)
	{
		// Do something after the action executes.
		ChangeLog log = new ChangeLog()
		{Log = this._chengeMessage};
		changeLogRepository.Add(log);
		changeLogRepository.Commit();
	}
}
In your controller, you can use it before actions you want to log like
[TrackMyChange("Your change log here")]
public IActionResult Post()
{
}
---------------------------------------------------------
**Reference :**
[Action Filter Attributes in .NET core][1]
  [1]: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-3.0

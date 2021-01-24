public override ViewEngineResult FindView(ActionContext actionContext, ViewResult viewResult)
{
	if (viewResult.ViewData.Model is IResult result)
	{
		if (result.Error != null)
		{
			var errorModel = new ErrorViewModel
			{
				Message = result.Error.Message;
			};
			viewResult.ViewData.Model = errorModel;
			viewResult.ViewName = "Error";
		}
		else
		{
			viewResult.ViewData.Model = result.ViewModel;
		}
	}
	return base.FindView(actionContext, viewResult);
}
And registered it in `Startup.cs` in `ConfigureServices(IServiceCollection services)` before any other code:
services.TryAddSingleton<IActionResultExecutor<ViewResult>, MyViewResultExecutor>();
It works. If someone can suggest a better solution or just an alternative, I'll still be interested to know.
  [1]: https://stackoverflow.com/a/43269630/1844247

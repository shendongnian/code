    public class DefaultCommandSettingsActionFilter : IAsyncActionFilter
    		{
    			public async Task OnActionExecutionAsync(
    				ActionExecutingContext context,
    				ActionExecutionDelegate next)
    			{
    				var command = context.ActionArguments.Values.FirstOrDefault(x => x is ICommand);
    				if(command != null)
    					((dynamic)command).TestHarness = "Set values here!";
    
    				await next();
    			}
    		}

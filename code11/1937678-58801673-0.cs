    public class MyExceptionFilter : IExceptionFilter
    {
    	public void OnException(ExceptionContext context)
    	{
    		if (context?.Exception.Message == "Did it catch this?")
    		{
    			context.Result = new BadRequestObjectResult("You have no access.");
    		}
    	}
    }

    public class CheckArgumentTypeAttribute : ActionFilterAttribute
    {
    	private readonly string ActionArgumentName;
    
    	public CheckArgumentIsPositiveAttribute(string actionArgumentName)
    	{
    		if (string.IsNullOrWhiteSpace(actionArgumentName)) throw new ArgumentException(nameof(actionArgumentName));
    		ActionArgumentName = actionArgumentName;
    	}
    
    	public override void OnActionExecuting(HttpActionContext actionContext)
    	{
    		var keyValuePair = actionContext.ActionArguments.FirstOrDefault(x => x.Key.Equals(ActionArgumentName, StringComparison.OrdinalIgnoreCase));
    		if (keyValuePair.Equals(default(KeyValuePair<string, object>)) || !int.TryParse(keyValuePair.Value, out in result))
    		{
    			actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
    			{
    				Content = new StringContent(JsonConvert.SerializeObject(new YourClass())), Encoding.UTF8, MimeTypes.Application.Json)
    			};
    		}
    	}
    }

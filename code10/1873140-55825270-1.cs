    public class ErrorResult
    {
    	public int code { get; set; }
    	public string message { get; set; }
    
    	public ErrorResult()
    	{
    	}
    
    	public ErrorResult(ModelStateDictionary.ValueEnumerable modelState)
    	{
            // This will take the error message coming directly from modelState
    		foreach (var value in modelState)
    		{
    			if (value.Errors.Count > 0)
    			{
    				code = 900; // Or use a code handler or whatever
    				message = value.Errors.FirstOrDefault().ErrorMessage;
    				break;
    			}
    		}
    	}
    }

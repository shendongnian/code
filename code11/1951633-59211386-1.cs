    public class CustomBadRequest
    {
    	[JsonProperty("httpstatuscode")]
    	public string HttpStatusCode { get; set; }
    	
    	[JsonProperty("errors")]
    	public List<YourErrorClass> Errors { get; set; } = new List<YourErrorClass>();
    
    	public CustomBadRequest(ActionContext context)
    	{
    		this.HttpStatusCode = "400";
    		this.Errors = new List<YourErrorClass>();
    		this.ConstructErrorMessages(context);
    	}
    
    	private void ConstructErrorMessages(ActionContext context)
    	{
    		foreach (var keyModelStatePair in context.ModelState)
    		{
    			var key = keyModelStatePair.Key;
    			var errors = keyModelStatePair.Value.Errors;
    			if (errors != null && errors.Count > 0)
    			{
    				foreach (var error in errors)
    				{
    					Errors.Add(new YourErrorClass()
    					{
    						ErrorMessage = errors[0].ErrorMessage
    						// add additional information, if you like
    					});
    				}
    			}
    		}
    }

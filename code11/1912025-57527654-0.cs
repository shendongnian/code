    public class CustomConfigModel
    { 
    	public CustomConfigModel()
    	{		
    		this.data = new ExpandoObject();
    		this.config = new ExpandoObject();
    	}
    	
    	public dynamic data { get; set; } 
    	public dynamic config { get; set; }
    }

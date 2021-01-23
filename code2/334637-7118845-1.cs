    public class RootActivity : Activity
    {
    	public InArgument<string> TestArg {get; set;}
    	
    	public RootActivity(Activity child)
    	{
    		Implementation = () => child;
    	}
    }

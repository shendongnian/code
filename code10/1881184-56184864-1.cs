    public class ShellViewModel:Screen, IHandle<AuthenticationSuccessMessage>
    {
    	void Handle<AuthenticationSuccessMessage>(AuthenticationSuccessMessage message)
    	{
    		if(message.IsValidLogin)
    		{
    			// Do Task
    		}
    	}
    }

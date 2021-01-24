    public class ShellViewModel:Screen, IHandle<AuthenticationSuccessMessage>
    {
       private readonly IEventAggregator _eventAggregator;
       public ShellViewModel:Screen(IEventAggregator eventAggregator) {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }
    	void Handle<AuthenticationSuccessMessage>(AuthenticationSuccessMessage message)
    	{
    		if(message.IsValidLogin)
    		{
    			// Do Task
    		}
    	}
    }

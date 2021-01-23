    public class Mediator
    {
    	public static readonly Mediator Current = new Mediator();
    	public event EventHandler<EventArgs> EventRaised;
    	public void RaiseEvent(object sender, EventArgs eventArgs)
    	{
    		if (EventRaised!=null) 
    			EventRaised(sender, eventArgs);
    	}
    }
    public class PublisherEventArgs : EventArgs
    {
    	public string SomeData { get; set; }
    }
    public class Publisher
    {
    	public void Publish(string data)
    	{
    		Mediator.Current.RaiseEvent(this, new PublisherEventArgs() { SomeData = data} );
    	}
    }
    public class Subscriber
    {
    	public Subscriber()
    	{
    		Mediator.Current.EventRaised += HandlePublishedEvent;
    	}
    		
    	private void HandlePublishedEvent(object sender, EventArgs e)
    	{
    		if(e is PublisherEventArgs)
    		{
    			string data = ((PublisherEventArgs)e).SomeData;
    			// todo: do something here
    		}
    	}
    }

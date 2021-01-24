    public class EventReceived: INotification {
        public EventReceived()
        {
    
        }
    }
    
    
    
    public class EventReceivedHandler: INotificationHandler<EventReceived>
    {
        public async Task Handle(EventReceived evt){
            //do some stuff...
        }
    }
    
    
    [TestFixture]
    public class EventReceivedHandlerTests 
    {
    	[Test]
    	public async Task DoesSomeStuff()
    	{
    		//arrange
    		//(insert mocked interfaces to handler if required)
    		var eventHandler = new EventReceivedHandler();
    		var evt = new EventReceived();
    
    		//act
    		await eventHandler.Handle(evt);
    
    		//assert
    		//.......
    	}
    }

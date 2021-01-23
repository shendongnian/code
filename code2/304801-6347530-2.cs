    [CallbackBehaviorAttribute(UseSynchronizationContext = true)]
	public class SubCallback : IRemoteDebug	
    {
          public void Event(SomeClass evt)
  	      {
             // some handling code using: 
             //public delegate void EventCallbackHandler(SomeClass evt);
	      }
     }
    InstanceContext ctx = new InstanceContext(new SubCallback ());
    MyClient _client = new MyClient(
                ctx,
                new NetNamedPipeBinding(NetNamedPipeSecurityMode.None),
                new EndpointAddress("net.pipe://localhost/ServiceEndpointName"));

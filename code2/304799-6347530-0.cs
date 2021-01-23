    [CallbackBehaviorAttribute(UseSynchronizationContext = true)]
	public class SubCallback : IRemoteDebug	
{
    InstanceContext ctx = new InstanceContext(new EventClient.SubCallback());
    MyClient _client = new MyClient(
                ctx,
                new NetNamedPipeBinding(NetNamedPipeSecurityMode.None),
                new EndpointAddress("net.pipe://localhost/ServiceEndpointName"));

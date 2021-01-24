    public interface IHubContext<THub> where THub : Hub
	{
		IHubClients Clients { get; }
        IGroupManager Groups { get; }
	}

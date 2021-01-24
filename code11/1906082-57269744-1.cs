    public interface IHubContext<THub, T> where THub : Hub<T> where T : class
	{
		IHubClients<T> Clients { get; }
        IGroupManager Groups { get; }
	}

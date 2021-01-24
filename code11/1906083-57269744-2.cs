    // for untyped hub
    public interface IHubContext
    {
        IHubConnectionContext<dynamic> Clients { get; }
        IGroupManager Groups { get; }
    }
    // for typed hub
    public interface IHubContext<T>
    {
        IHubConnectionContext<T> Clients { get; }
        IGroupManager Groups { get; }
    }

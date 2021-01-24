    public interface IServer { }
    public interface IClient { }
    public class Server : IServer
    {
        [Dependency]
        public IClient Client { get; set; }
    }
    public class Client : IClient
    {
        [Dependency]
        public IServer Server { get; set; }
    }

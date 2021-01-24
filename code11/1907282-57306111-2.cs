    public interface IServer { }
    public interface IClient { }
    public class Server : IServer
    {
        public Server(IClient client) { }
    }
    public class SimpleServer : IServer { }
    public class Client : IClient
    {
        public Client(IServer server) { }  /* Should be registered to SimpleServer implementation */
    }

    public interface IServer { void Receive(string message); void SendToClient(string message); }
    public interface IClient { void Receive(string message); void SendToServer(string message); }
    
    public class Client : IClient
    {
        private readonly IServer _server;
        
        public Client(IServer server) => _server = server;
    
        public void SendToServer(string message) => _server.Receive(message);
    
    	public void Receive(string message) => Console.WriteLine($"Client received: {message}");
    }
    
    public class Server : IServer
    {
        private readonly Lazy<IClient> _client;
    
        public Server(Func<IClient> clientFactory) 
            => _client = new Lazy<IClient>(() => clientFactory());
    
        public void SendToClient(string message) => _client.Value.Receive(message);
    
    	public void Receive(string message) => Console.WriteLine($"Server received: {message}"); }
    }
    void Main()
    {
        var container = new UnityContainer();
        container.RegisterType<IClient, Client>();
        container.RegisterType<IServer, Server>();
        var server = container.Resolve<IServer>();
        var client = container.Resolve<IClient>();
        server.SendToClient("Foo");
        client.SendToServer("Bar");
    }

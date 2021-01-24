    public interface IServer { void Receive(string message); void SendToClient(string message); }
    public interface IClient { void Receive(string message); void SendToServer(string message); }
    
    public class Client : IClient
    {
        // This will be set as SimpleServer-implementation
        private readonly IServer _server;
        
        public Client(IServer server) => _server = server;
    
        public void SendToServer(string message) => _server.Receive(message);
    
    	public void Receive(string message) => Console.WriteLine($"Client received: {message}");
    }
    
    public class Server : IServer
    {
        private readonly IClient _client;
    
        public Server(IClient client) => _client = client;
    
        public void SendToClient(string message) => _client.Receive(message);
    
    	public void Receive(string message) => Console.WriteLine($"Server received: {message}");
    }
    
    public class SimpleServer : IServer
    {
    	public void SendToClient(string message) { }
    
    	public void Receive(string message) => Console.WriteLine($"SimpleServer received: {message}");
    }
    void Main()
    {
        var container = new UnityContainer();
    	container.RegisterType<IServer, Server>();
    	container.RegisterType<IClient, Client>(new InjectionConstructor(container.Resolve<SimpleServer>()));
    
    	var server = container.Resolve<IServer>();
    	var client = container.Resolve<IClient>();
    
    	server.SendToClient("Foo");
    	client.SendToServer("Bar");
    }

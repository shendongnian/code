    public interface IPacketFactory
    {
       IPacket CreatePacket();
       IPacket CreatePacket(Client creator, DateTime creationTime, string data);
    }
    
    public class MessageFactory : IPacketFactory
    {
       public CreatePacket()
       {
          return new Message();
       }
    
       public CreatePacket(Client creator, DateTime creationTime, string data)
       {
          return new Message(creator, creationTime, data);
       }
    }
    
    //You'd implement factories for each IPacket type...
    
    public class Client
    {
       private IPacketFactory _factory;
    
       public Client(IPacketFactory factory)
       {
          _factory = factory;
       }
    
       public SomeMethodThatNeedsToCreateIPacketInstance()
       { 
          IPacket packet = _factory.CreatePacket();
          
         //work with packet without caring what type it is
       }
    
    }
    
    
    //a higher level class or IOC container would construct the client with the appropriate factory
    
    Client client = new Client(new MessageFactory());
    
    // the Client class can work with different IPacket instances without it having to change (it's decoupled)
    Client client2 = new Client(new LogFactory());

    public class MessageFactory : IPacketFactory
    {
       private object _data;
    
       public MessageFactory(object extraData)
       {
          _data = extraData;
       }
    
        IPacket CreatePacket(Client creator, DateTime creationTime, string data)
        {
           return new Message(creator, creationTime, data, _extraData);
        }
    
        ///rest of implementation
    }

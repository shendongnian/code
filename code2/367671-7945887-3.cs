    //in MessageFactory : the PacketContext holds various data that may be relevant to creation
    
    public IPacket Create(Client creator, DateTime creationTime, string data, PacketContext ctx)
    {
       return new Message(creator, creationTime, data, ctx.SomeExtraData); 
    }
    
    //in LogFactory: the Log doesn't need anything from the PacketContext but it does call something on the Client (Double Dispatch)
    
    public IPacket Create(Client creator, DateTime creationTime, string data, PacketContext ctx)
    {
       return new Log(creator.Name, creationTime, data);
    }

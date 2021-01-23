    public interface ICredentials {}
    public interface IMessage
    {
        //properties
        string Text {get;set;}
        DateTime TimeStamp { get; set; }
        IChannel Channel { get; set; }
    }
    public interface IChannel
    {
        //properties
        ReadOnlyCollection<IUser> Users {get;}
        ReadOnlyCollection<IMessage> MessageHistory { get; }
        //abilities
        bool Add(IUser user);
        void Remove(IUser user);
        void BroadcastMessage(IMessage message);
        void UnicastMessage(IMessage message);
    }
    public interface IUser
    {
        string Name {get;}
        ICredentials Credentials { get; }
        bool Add(IChannel channel);
        void Remove(IChannel channel);
        void ReceiveMessage(IMessage message);
        void SendMessage(IMessage message);
    }

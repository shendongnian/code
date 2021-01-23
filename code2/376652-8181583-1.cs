    public interface IMessage
    {
    }
    public class PlayerDraw: IMessage
    {
        public AnyType Arguments { get; set; }
    }
    public interface IMessageHandler<T> where T: IMessage
    {
        void Handle(T message);
    }
    private class MessageHandlers: 
       IMessageHandler<PlayerDraw>, 
       IMessageHandler<PlayerHold>
    {
        public void Handle(PlayerDraw message)
        {
            // Use your message here;
        }
        public void Handle(PlayerHold message)
        {
            // Use your message here;
        }
    }
    public class GameManager
    {
        private readonly Dictionary<Type, Action<IMessage>> _messageRoutes = 
            new Dictionary<Type, Action<IMessage>>();
        public void RegisterHandler<T>(Action<T> handler) where T : IMessage
        { ... }
        public void Send<T>(T message) where T : IMessage
        { ... }
    }

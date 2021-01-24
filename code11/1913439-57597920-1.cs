    public interface IMessageHandler
    {
        void HandleMessage(IQueueMessage message);
    }
    public class MessageHandlerWrapper<T> : IMessageHandler
    {
        private readonly IMessageHandler<T> _handler;
        public MessageHandlerWrapper(IMessageHandler<T> handler)
        {
            _handler = handler;
        }
        public void HandleMessage(IQueueMessage message)
        {
            _handler.HandleMessage(
                new Message<T>(
                    (T)message.Message,
                    message.Id, 
                    message.MessageType, 
                    message.ConsumeDate));
        }
    }

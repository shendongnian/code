    public interface IMessageHandler
    {
        void HandleMessage(IQueueMessage message);
    }
    public class MessageHandlerWrapper<TMessage> : IMessageHandler
    {
        private readonly IMessageHandler<TMessage> _handler;
        public MessageHandlerWrapper(IMessageHandler<TMessage> handler)
        {
            _handler = handler;
        }
        // This is the critical part - it gets us from object to TMessage.
        public void HandleMessage(IQueueMessage message)
        {
            _handler.HandleMessage(
                new Message<TMessage>(
                    (TMessage)message.Message,
                    message.Id,
                    message.MessageType,
                    message.ConsumeDate));
        }
    }

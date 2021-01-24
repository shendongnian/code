    public class MessageRouter : IMessageHandler
    {
        private readonly IMessageHandlerFactory _messageHandlerFactory;
        public MessageRouter(IMessageHandlerFactory messageHandlerFactory)
        {
            _messageHandlerFactory = messageHandlerFactory;
        }
        public void HandleMessage(QueueMessage message)
        {
            var handler = _messageHandlerFactory.GetHandler(message.MessageType);
            handler.HandleMessage(message);
        }
    }

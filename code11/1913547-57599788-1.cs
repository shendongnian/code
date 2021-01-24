    public class MessageHandlerWrapper<TContent> : IMessageHandler
    {
        private readonly IMessageHandler<TContent> _handler;
        public MessageHandlerWrapper(IMessageHandler<TContent> handler)
        {
            _handler = handler;
        }
        public void HandleMessage(QueueMessage message)
        {
            var content = JsonConvert.DeserializeObject<TContent>(message.Body);
            _handler.HandleMessage(
                new Message<TContent>(
                    content,
                    message.Id,
                    message.Received));
        }
    }

    public class MessageHandlerFactory : IMessageHandlerFactory
    {
        private readonly Dictionary<string, Func<IMessageHandler>> _messageHandlers
            = new Dictionary<string, Func<IMessageHandler>>(StringComparer.OrdinalIgnoreCase);
        public void RegisterHandler(string messageType, Func<IMessageHandler> getHandlerFunction)
        {
            _messageHandlers[messageType] = getHandlerFunction;
        }
        public IMessageHandler GetHandler(string messageType)
        {
            if (_messageHandlers.ContainsKey(messageType))
                return _messageHandlers[messageType]();
            throw new InvalidOperationException($"No handler is registered for message type {messageType}.");
        }
    }

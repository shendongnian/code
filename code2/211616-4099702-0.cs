    public abstract class MessageHandlerBase<T> : IMessageHandler<T> where T : IMessage
    {
        public abstract void HandleMessage(T message);
        public void Handle(T message)
        {
            if (CredentialsValid(message))
                this.HandleMessage(message);
        }
    }

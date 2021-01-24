	interface IMessagingExchange
    {
        void Bind(IMessagingQueue queue);
    }
    interface IMessagingExchange<TQueue> : IMessagingExchange where TQueue : IMessagingQueue
    {
        void Bind(TQueue queue);
    }

    abstract class ExchangeBase<TQueue> : IMessagingExchange<TQueue>  where TQueue : class, IMessagingQueue
    {
        public abstract void Bind(TQueue queue);
        
        public void Bind(IMessagingQueue queue)
        {
            var typedQueue = queue as TQueue;
            if (typedQueue == null)
                throw new InvalidOperationException($"This exchange only supports queues that implement {typeof(TQueue).FullName}");
            Bind(typedQueue);
        }
    }

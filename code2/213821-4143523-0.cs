    public interface IProducer<T> : IStoppable
    {
        /// <summary>
        /// Notifies clients when a new item is produced.
        /// </summary>
        event EventHandler<ProducedItemEventArgs<T>> ItemProduced;
    }
    public interface IConsumer<T> : IStoppable
    {
        /// <summary>
        /// Performs processing of the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void ConsumeItem(T item);
    }
    

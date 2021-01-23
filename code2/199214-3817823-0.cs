    public sealed class CollectionEventMonitor<TItem, TEventArgs> : IDisposable
        where TEventArgs: EventArgs
    {
        private readonly INotifyCollectionChanged _collection;
        private readonly Action<TItem, EventHandler<TEventArgs>> _addEvent;
        private readonly Action<TItem, EventHandler<TEventArgs>> _removeEvent;
        public event EventHandler<TEventArgs> ItemFiredEvent;
        public CollectionEventMonitor(INotifyCollectionChanged collection, 
            Action<TItem, EventHandler<TEventArgs>> addEvent, 
            Action<TItem, EventHandler<TEventArgs>> removeEvent)
        {
            _addEvent = addEvent;
            _removeEvent = removeEvent;
            _collection = collection;
            _collection.CollectionChanged += _collection_CollectionChanged;
        }
        void _collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems.Cast<TItem>())
                        _addEvent(item, OnItemFiredEvent);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems.Cast<TItem>())
                        _removeEvent(item, OnItemFiredEvent);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    foreach (var item in e.OldItems.Cast<TItem>())
                        _removeEvent(item, OnItemFiredEvent);
                    foreach (var item in e.NewItems.Cast<TItem>())
                        _addEvent(item, OnItemFiredEvent);
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    foreach (var item in e.OldItems.Cast<TItem>())
                        _removeEvent(item, OnItemFiredEvent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void OnItemFiredEvent(Object item, TEventArgs eventArgs)
        {
            var handler = ItemFiredEvent;
            if (handler != null)
                handler(item, eventArgs);
        }
        public void Dispose()
        {
            _collection.CollectionChanged -= _collection_CollectionChanged;
        }
    }

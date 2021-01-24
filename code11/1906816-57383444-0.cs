    public class UntilSubscribeReplay<T> : IObservable<T>
    {
        private readonly IObservable<T> _parent;
    
        private HashSet<IObserver<T>> _observers = new HashSe
        private IDisposable _subscription;
        private readonly Queue<T> _itemsQueue = new Queue<T>(
    
        public UntilSubscribeReplay(IObservable<T> parent)
        {
            _parent = parent;
            Subscribe();
        }
    
        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (_subscription == null)
                Subscribe();
    
            _observers.Add(observer);
            EmitQueuedItems();
    
            return Disposable.Create(() =>
            {
                _observers.Remove(observer);
                if (_observers.Count == 0)
                    _subscription.Dispose();
            });
        }
    
        private void Subscribe()
        {
            _subscription = _parent
                .Do(_itemsQueue.Enqueue)
                .Subscribe(_ => EmitQueuedItems());
        }
    
        private void EmitQueuedItems()
        {
            if (_observers.Count == 0)
                return;
    
            while (_itemsQueue.TryDequeue(out T item))
            {
                foreach (IObserver<T> observer in _observers)
                {
                    observer.OnNext(item);
                }
            }
        }
    }

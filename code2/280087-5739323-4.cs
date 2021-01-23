    public class Repository
    {
        public Repository()
        {
            _lazyStorage = new Lazy<IStorage>(StorageFactory);
        }
        private readonly Lazy<IStorage> _lazyStorage;
        private Dictionary<Guid, INode> NodeCache { get; set; }
        private Func<IStorage> StorageFactory { get; set; }
        public IObservable<INode> Fetch(IObservable<Guid> ids)
        {
            return Observable
                .CreateWithDisposable<INode>(observer =>
                    ids.Subscribe(x =>
                    {
                        INode node;
                        if (NodeCache.TryGetValue(x, out node))
                            observer.OnNext(node);
                        else
                        {
                            node = _lazyStorage.Value.Fetch(x);
                            NodeCache[x] = node;
                            observer.OnNext(node);
                        }
                    }, observer.OnError, observer.OnCompleted));
        }
    }

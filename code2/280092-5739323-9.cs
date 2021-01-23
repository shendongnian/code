    public class Repository
    {
        public Repository()
        {
            _lazyStorage = new Lazy<IStorage>(StorageFactory);
        }
        private readonly Lazy<IStorage> _lazyStorage;
        private Dictionary<Guid, INode> NodeCache { get; set; }
        private Func<IStorage> StorageFactory { get; set; }
        private IObservable<INode> Fetcher(Guid id)
        {
            return Observable.Defer(() =>
            {
                INode node;
                return NodeCache.TryGetValue(id, out node)
                    ? Observable.Return(node)
                    : _lazyStorage.Value.Fetch(id);
            });
        }
        public IObservable<INode> Fetch(IObservable<Guid> ids)
        {
            return ids.Select(Fetcher).Concat();
        }
    }

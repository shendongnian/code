    public class MyService : IDisposable
    {
        private SourceCache<MyData, Guid> _localCache = new SourceCache<MyData, Guid>(x=> x.Id);
        private SourceCache<MyData, Guid> _serverCache = new SourceCache<MyData, Guid>(x=> x.Id);
        public MyService()
        {
            var localdata = _localCache.Connect();
            var serverdata = _serverCache.Connect();
            var alldata = localdata.Merge(serverdata);
            AllData = alldata.AsObservableCache();
        }
        public IObservableCache<MyData, Guid> AllData { get; }
        public IObservable<Unit> TriggerLocal()
        {
            return LoadLocalAsync().ToObservable();
        }
        public IObservable<Unit> TriggerServer()
        {
            return LoadServerAsync().ToObservable();
        }
    }

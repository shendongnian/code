    using (var locker = new PurchaseLocker(item.Id))
    {
        // order stuff like counting current amount of orders, buyer validity etc
    }
    // ...
      
    public sealed class PurchaseLocker : IDisposable
    {
        private static readonly object _bigLock = new object();
        private static readonly Dictionary<Guid, LockToken> _lockMap = new Dictionary<Guid, LockToken>();
        private readonly Guid _itemId;
        public PurchaseLocker(Guid itemId)
        {
            _itemId = itemId;
            LockToken miniLock;
            lock (_bigLock)
            {
                if (!_lockMap.TryGetValue(itemId, out miniLock))
                {
                    miniLock = new LockToken();
                    _lockMap.Add(itemId, miniLock);
                }
                miniLock.Count++;
            }
            Monitor.Enter(miniLock);
        }
        public void Dispose()
        {
            lock (_bigLock)
            {
                LockToken miniLock = _lockMap[_itemId];
                miniLock.Count--;
                if (miniLock.Count == 0)
                    _lockMap.Remove(_itemId);
                Monitor.Exit(miniLock);
            }
        }
        private sealed class LockToken
        {
            public int Count;
        }
    }

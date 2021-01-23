    public static class HotSpotsCache
    {
        private static readonly Dictionary<short, List<HotSpot>>
            _hotSpotsMap = new Dictionary<short, List<HotSpot>();
        private static readonly object _bigLock = new object();
        private static readonly Dictionary<short, object>
            _miniLocks = new Dictionary<short, object>();
        public static List<HotSpot> GetCompanyHotSpots(short companyId)
        {
            List<HotSpot> hotSpots;
            object miniLock;
            lock (_bigLock)
            {
                if (_hotSpotsMap.TryGetValue(companyId, out hotSpots))
                    return hotSpots;
                if (!_miniLocks.TryGetValue(companyId, out miniLock))
                {
                    miniLock = new object();
                    _miniLocks.Add(companyId, miniLock);
                }
            }
            lock (miniLock)
            {
                if (!_hotSpotsMap.TryGetValue(companyId, out hotSpots))
                {
                    hotSpots = LoadHotSpots(companyId);
                    lock (_bigLock)
                    {
                        _hotSpotsMap.Add(companyId, hotSpots);
                        _miniLocks.Remove(companyId);
                    }
                }
                return hotSpots;
            }
        }
        
        private static List<HotSpot> LoadHotSpots(short companyId)
        {
            return ServiceProvider.Instance
                                  .GetService<HotSpotsService>()
                                  .GetHotSpots(/* ... */);
        }
    }

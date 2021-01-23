    public static class HotSpotsCache
    {
        private static readonly ConcurrentDictionary<short, List<HotSpot>>
            _hotSpots = new ConcurrentDictionary<short, List<HotSpot>>();
        public static List<HotSpot> GetCompanyHotSpots(short companyId)
        {
            return _hotSpots.GetOrAdd(companyId, id => LoadHotSpots(id));
        }
        
        private static List<HotSpot> LoadHotSpots(short companyId)
        {
            // ...
            return ServiceProvider.Instance
                                  .GetService<HotSpotsService>()
                                  .GetHotSpots(/* ... */);
        }
    }

    public static class HotspotsCache
    {
        private static Dictionary<short, List<HotSpot>> _companyHotspots = new Dictionary<int, List<HotSpot>>();
        static HotspotsCache()
        {
            foreach(short companyId in allCompanies)
            {
                companyHotspots.Add(companyId, new List<HotSpot>());
            }
        }
        public static List<HotSpot> GetCompanyHotspots(short companyId)
        {
            List<HotSpots> result = _companyHotspots[companyId];
            if(result.Count == 0)
            {
                lock(result)
                {
                    if(result.Count == 0)
                    {
                        RefreshCompanyHotspotCache(companyId, result);
                    }
                }
            }
            return result;
        }
        private static void RefreshCompanyHotspotCache(short companyId, List<HotSpot> resultList)
        {
            ....
            hotspots = ServiceProvider.Instance.GetService<HotspotsService>().GetHotSpots(..);
            resultList.AddRange(hotspots);
            ....
        }
    }

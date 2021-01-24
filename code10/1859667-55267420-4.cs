	private async Task<string> GetOrAddAsync(string cacheKey, bool useCaching, int cacheDays, DateTime currYear, ? currQuarter, ? currYearType, Action<string, string, string> cacheFactory)
	{
		if(DashboardCacheHelper.IsIncache(cacheKey, useCaching))
		{
			return DashboardCacheHelper.GetFromCache(cacheKey);
		}
		
		return (string)(await DashboardCacheHelper.SaveCacheAsync(bidsClosedKey, JsonConvert.SerializeObject(cacheFactory(currYear.ToString(), currQuarter.ToString(), currYearType.ToString())), DateTime.Now.AddDays(cacheDays)).ConfigureAwait(false))
	}

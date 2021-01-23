    // Consider this psuedo code for using Cache
    public DataSet GetMySearchData(string search)
    {
        // if it is in my cache already (notice search criteria is the cache key)
        string cacheKey = "Search " + search;
        if (Cache[cacheKey] != null)
        {
            return (DataSet)(Cache[cacheKey]);
        }
        else
        {
            DataSet result = yourDAL.DoSearch(search);
            Cache[cacheKey].Insert(result);  // There are more params needed here...
            return result;
        }
    }

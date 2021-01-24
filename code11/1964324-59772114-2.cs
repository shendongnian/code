    class BaseCache
    {
        int X { get; set; }
        int Y { get; set; }
        int Z { get; set; }
    }
    class NOT_DEFINED_CACHE : BaseCache {}
    public CACHE_TYPE GetCache<CACHE_TYPE>() where CACHE_TYPE : BaseCache, new()
    {
        CACHE_TYPE result = new CACHE_TYPE();
        result.X = 1:
        result.Y = 2:
        result.Z = 3:
        return result;
    }

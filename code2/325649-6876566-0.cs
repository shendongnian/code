    private static readonly myLockObject = new object();
    
    public static List<Kategorie> GetKategorieTitelListe(Cache appCache)
    {
        // get Data out of Cache
        List<Kategorie> katList = appCache[CachedData.NaviDataKey] as List<Kategorie>;
        lock (myLockObject)
        {
            // Cache expired, retrieve and store again
            if (katList == null)
            {
                katList = DataTools.BuildKategorienTitelListe();
                appCache.Insert(CachedData.NaviDataKey, katList, null, DateTime.Now.AddDays(1d), Cache.NoSlidingExpiration);
            }
            return katList;
        }
    }

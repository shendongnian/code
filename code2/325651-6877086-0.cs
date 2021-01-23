    private static readonly object _locker = new object ();
    public static List<Kategorie> GetKategorieTitelListe(Cache appCache)
    {
        List<Kategorie> katList;
        lock (_locker)
        {
            // get Data out of Cache
            katList = appCache[CachedData.NaviDataKey] as List<Kategorie>;
            // Cache expired, retrieve and store again
            if (katList == null)
            {
                    katList = DataTools.BuildKategorienTitelListe();
                    appCache.Insert(CachedData.NaviDataKey, katList, null, DateTime.Now.AddDays(1d), Cache.NoSlidingExpiration);
            }
        }
        return katList;
    }

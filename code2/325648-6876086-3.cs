    // this must be class level variable!!!
    private static readonly object locker = new object();
    
        public static List<Kategorie> GetKategorieTitelListe(Cache appCache)
        {
            // get Data out of Cache
            List<Kategorie> katList = appCache[CachedData.NaviDataKey] as List<Kategorie>;
            // Cache expired, retrieve and store again
            if (katList == null)
            {
                lock (locker)
                {
                    katList = appCache[CachedData.NaviDataKey] as List<Kategorie>;
                    if (katlist == null)  // make sure that waiting thread is not executing second time
                    {
                        katList = DataTools.BuildKategorienTitelListe();
                        appCache.Insert(CachedData.NaviDataKey, katList, null, DateTime.Now.AddDays(1d), Cache.NoSlidingExpiration);
                    }
                }
            }
            return katList;
        }

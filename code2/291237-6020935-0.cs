    class MainFetcher : IPriceFetcher {
    
     IEnumerable< IPriceSource > mSource;
     IPriceCache mCache;
    
     public MainFetcher( IEnumerable< IPriceSource > pSource, IPriceCache pCache )
     {
         mSource = pSource;
         mCache = pCache; 
     }
     public double GetPrice(int pID)
     {
         double tPrice;
         // get from cache
         if (mCache.TryGet(pID, out tPrice) {
             return tPrice;
         } else {
             // throws if no source found
             tPrice = mSource
                 .First(tArg => tArg != null)
                 .GetPrice(pID);
             // add to cache
             mCache.Add(pID, tPrice);
         }
     }
    }

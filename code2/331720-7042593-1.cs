    public class MyListFetcher<T>
    {
         public List<T> FetchData()
         {
              List<T> obj = HttpRuntime.Cache["myObjectCacheKey"] as List<T>;
              if(obj != null)
                 return obj;
              obj = FetchDataFromDatabase();
              HttpRuntime.Cache.Insert("myObjectCacheKey", obj, null, DateTime.Now.AddMinutes(5), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
              // Inserts the item and keeps it there for five minutes; then the cache will be invalidated. No sliding expiration
             return obj;
         } 
         protected List<T> FetchDataFromDatabase()
         {
             // Your DB fetch code
         }
    }

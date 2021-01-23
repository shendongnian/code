    public class Foo
    {
         public void WorkItem()
         {
             ClientEntityCache.EntityCacheCleared +=
    new MyDelegate(ClientEntityCache_CacheCleared);
         }
         public void Dispose()
         {
             ClientEntityCache.EntityCacheCleared -=
    new MyDelegate(ClientEntityCache_CacheCleared);
         }
    }

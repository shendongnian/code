    public class Foo
    {
         private MyDelegate Foo = ClientEntityCache_CacheCleared;
         public void WorkItem()
         {
             ClientEntityCache.EntityCacheCleared += Foo;
         }
         public void Dispose()
         {
             ClientEntityCache.EntityCacheCleared -= Foo;
         }
    }

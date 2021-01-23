    public class CachingAroundAdvice : IMethodInterceptor
    {
        #region Variable Declarations
        private Priority priority = Priority.Normal;
        #endregion
        public object Invoke(IMethodInvocation invocation)
        {
            // declare local variables
            string cacheKey = string.Empty;
            object dataObject = null;
           
            // build cache key with some algorithm
            cacheKey = CreateCacheKey(invocation.Method, invocation.Arguments);
            
            // retrieve item from cache
            dataObject = CacheManager.Cache.GetData(cacheKey);
            // if the dataobject is not in cache proceed to retrieve it
            if (null == dataObject)
            {
                dataObject = invocation.Proceed();
                // add item to cache
                CacheManager.Cache.Add(cacheKey, dataObject, CachePriority, null, Expiration);
            }
            // return data object
            return dataObject;
        }

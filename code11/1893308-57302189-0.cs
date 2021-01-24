    public static DateTime GetCachePriority(string strKey)
    {
        object cacheProvider = HttpRuntime.Cache.GetType().GetProperty("InternalCache", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(HttpRuntime.Cache, null);
        			object intenralCacheStore = cacheProvider?.GetType().GetField("_cacheInternal", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(cacheProvider);
        			if(intenralCacheStore != null)
        			{
        				Type cacheOption = HttpRuntime.Cache.GetType().Assembly.GetTypes().FirstOrDefault(d => d.Name == "CacheGetOptions");
        				MethodInfo methodInfo = intenralCacheStore.GetType().GetMethod("DoGet", BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Any,
        				                                                               new[] { typeof(bool), typeof(string), cacheOption }, null);
        
        				if(methodInfo != null)
        				{
        					dynamic cacheEntry = methodInfo.Invoke(intenralCacheStore, new Object[] { true, strKey, 1 });
        
        					PropertyInfo usageBucketProperty = cacheEntry.GetType().GetProperty("UsageBucket", BindingFlags.NonPublic | BindingFlags.Instance);
        					byte byPriority = (byte) usageBucketProperty.GetValue(cacheEntry, null);
        					CacheItemPriority prriority = byPriority == byte.MaxValue ? CacheItemPriority.NotRemovable : (CacheItemPriority)byPriority + 1;
        					strPriority = prriority.ToString();
        				}
        			}
    }

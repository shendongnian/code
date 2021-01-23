    class CacheHelper
    {
    
        private static CacheWrapper GetWrapper()
        {
           return [Lib Namespace].[Class Name].[Field Name referring to CacheWrapper];
        }
    
    
        public static void Add<T>(string key, T value, int expireInMins)
        {
            var wrapper = GetWrapper();
            lock (wrapper)
            {
                wrapper.Add(key, value, expireInMins);
            }
        }
     
        ...
    

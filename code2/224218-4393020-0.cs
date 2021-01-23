    class Whatever
    {
        static Hashtable cache = Hashtable.Synchronized(new Hashtable());
    
        public static Object GetCachedObject(String key)
        {
            Object value = cache[key];
            if( value == null )
            {
                lock( cache.SyncRoot )
                {
                    value = cache[key];
                    if( value == null )
                    {
                        value = FetchValueFromWherever();
                        cache[key] = value;
                    }
                }
            }
            return value;
        }
    }

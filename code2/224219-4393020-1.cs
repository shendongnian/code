    class UrlFetcher
    {
        static Hashtable cache = Hashtable.Synchronized(new Hashtable());
    
        public static String GetCachedUrl(String url)
        {
            String value = (String)cache[url];
            if( value == null )
            {
                lock( cache.SyncRoot )
                {
                    value = (String)cache[url];
                    if( value == null )
                    {
                        value = FetchUrlFromWeb(url);
                        cache[key] = value;
                    }
                }
            }
            return value;
        }
    }

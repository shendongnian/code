    public static object CachedItem
    {
        get
        {
            string key = "item11"; // users share the object at this key
            object o = Cache[key];
            if (o == null)
            {
                o = {Get from some source};
                Cache.Add(key, o, null, Cache.NoAbs..., new TimeSpan(0,5,0), High, Removed);
            }
      
            return o;
        }
    }

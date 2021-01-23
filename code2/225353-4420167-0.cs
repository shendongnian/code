    public static class CacheHelper
    {
        public static void SetCache(string key, object value)
        {
            HttpContext.Current.Cache[key] = value;
            if (key == "some special key")
                WriteValueOnDisk(value);
        }
    }

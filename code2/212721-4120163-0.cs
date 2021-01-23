    public class Settings {
        private object SyncRoot = new object();
        private System.Collections.Hashtable _cache = new System.Collections.Hashtable();
        public T GetSetting<T>(string xPath, T defaultValue)
        {
            lock (SyncRoot)
            {
                if (!_cache.ContainsKey(xPath))
                {
                    T val = GetSettingFromDB<T>(xPath, defaultValue);
                    _cache[xPath] = val;
                    return val;
                }
                return (T)_cache[xPath];
            }
        }
        public T GetSettingFromDB<T>(string xPath, T defaultValue)
        {
             // Read from DB
        }
        public void SaveSetting<T>(string xPath, T value)
        {
            lock (SyncRoot)
            {
                if (_cache.ContainsKey(xPath))
                    _cache[xPath] = value;
            }
            
            SaveSettingToDB<T>(xPath, value);
        }
        public T SaveSettingToDB<T>(string xPath, T defaultValue)
        {
             // Read from DB
        }
    }

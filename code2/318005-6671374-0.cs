    public class ConfigSection<T>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(StringConfigSection));
        public static Dictionary<String, T> LoadSection(string sectionName, Func<String,T> parseFunc)
        {
            var ret = new Dictionary<String, T>();
            try
            {
                var offsetsHash = (Hashtable)ConfigurationManager.GetSection(sectionName);
                foreach (DictionaryEntry entry in offsetsHash)
                {
                    ret.Add((String)entry.Key, parseFunc((String)entry.Value));
                }
            }
            catch (Exception e)
            {
                Log.ErrorFormat("LoadSection:" + e);
            }
            return ret;
        }
    }

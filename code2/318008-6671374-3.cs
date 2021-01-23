    public class ConfigSection<T>
    {
        private Func<String, T> myParseFunc = null;
        public ConfigSection<T>(Func<String,T> parParseFunc)
        {
           myParseFunc = parParseFunc;
        }
        private static readonly ILog Log = LogManager.GetLogger(typeof(StringConfigSection));
        public static Dictionary<String, T> LoadSection(string sectionName)
        {
            var ret = new Dictionary<String, T>();
            try
            {
                var offsetsHash = (Hashtable)ConfigurationManager.GetSection(sectionName);
                foreach (DictionaryEntry entry in offsetsHash)
                {
                    ret.Add((String)entry.Key, myParseFunc((String)entry.Value));
                }
            }
            catch (Exception e)
            {
                Log.ErrorFormat("LoadSection:" + e);
            }
            return ret;
        }
    }

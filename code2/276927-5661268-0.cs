      public class DictionaryCollection<TType> : Dictionary<string,Dictionary<string,TType>> {
        public void Add(string dictionaryKey,string key, TType value) {
            if(!ContainsKey(dictionaryKey))
                Add(dictionaryKey,new Dictionary<string, TType>());
            this[dictionaryKey].Add(key,value);
        }
        public TType Get(string dictionaryKey,string key) {
            return this[dictionaryKey][key];
        }
    }

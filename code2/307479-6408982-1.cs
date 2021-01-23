    IDictionary<string, Point> _dictionary = GetDictionary();
    _dictionary.GetOrAdd( "asdf" ).Add( new Point(14, 15) );
    
    // ... elsewhere ...
    public static class DictionaryExtensions {
        public static List<TValue> GetOrAdd<TKey, TValue>( this IDictionary<TKey, List<TValue>> self, TKey key ) {
            List<TValue> result;
            self.TryGetValue( key, out result );
            if ( null == result ) {
                // the key value can be set to the null
                result = new List<TValue>();
                self[key] = result;
            }
    
            return result;
        }
    }

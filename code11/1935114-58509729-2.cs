    ```
    public class VerbatimDictionaryConverter<TKey, TValue> : JsonConverter<IDictionary<TKey, TValue>>
    {
        [JsonDictionary(NamingStrategyType = typeof(DefaultNamingStrategy))]
        class VerbatimDictionarySerializationSurrogate : IReadOnlyDictionary<TKey, TValue>
        {
            readonly IDictionary<TKey, TValue> dictionary;
            public VerbatimDictionarySerializationSurrogate(IDictionary<TKey, TValue> dictionary) 
			{ 
				if (dictionary == null) 
					throw new ArgumentNullException(nameof(dictionary));
				this.dictionary = dictionary; 
			}
            public bool ContainsKey(TKey key) { return dictionary.ContainsKey(key); }
            public bool TryGetValue(TKey key, out TValue value) { return dictionary.TryGetValue(key, out value); }
            public TValue this[TKey key] { get { return dictionary[key]; } }
            public IEnumerable<TKey> Keys { get { return dictionary.Keys; } }
            public IEnumerable<TValue> Values { get { return dictionary.Values; } }
            public int Count { get { return dictionary.Count; } }
            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() { return dictionary.GetEnumerator(); }
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }
        public override void WriteJson(JsonWriter writer, IDictionary<TKey, TValue> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, new VerbatimDictionarySerializationSurrogate(value));
        }
        public override bool CanRead { get { return false; } }
		
        public override IDictionary<TKey, TValue> ReadJson(JsonReader reader, Type objectType, IDictionary<TKey, TValue> existingValue, bool hasExistingValue, JsonSerializer serializer) { throw new NotImplementedException(); }
    }
    ```

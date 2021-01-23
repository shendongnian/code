        public static TKey GetKey<TKey,TValue>(Dictionary<TKey, TValue> dictionary, TValue Value)
        {
            List<TKey> KeyList = new List<TKey>(dictionary.Keys);
            foreach (TKey key in KeyList)
                if (dictionary[key].Equals(Value))
                    return key;
            throw new KeyNotFoundException();
        }

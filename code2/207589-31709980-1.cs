        public static TKey[] GetKeys<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TValue Value)
        {
            List<TKey> KeyList = new List<TKey>(dictionary.Keys);
            List<TKey> FoundKeys = new List<TKey>();
            foreach (TKey key in KeyList)
                if (dictionary[key].Equals(Value))
                    FoundKeys.Add(key);
            if (FoundKeys.Count > 0)
                return FoundKeys.ToArray();
            throw new KeyNotFoundException();
        }

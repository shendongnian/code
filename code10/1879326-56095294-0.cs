        public IDictionary<TKey, TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict, int count)
        {
            if (count > dict.Count) throw new ArgumentException("argument count must be less or equal to the size of dict");
            Random rand = new Random();
            Dictionary<TKey, TValue> randDict = new Dictionary<TKey, TValue>();
            do
            {
                int index = rand.Next(0, dict.Count);
                if (!randDict.ContainsKey(dict.ElementAt(index).Key))
                    randDict.Add(dict.ElementAt(index).Key, dict.ElementAt(index).Value);
            } while (randDict.Count < count);
            return randDict;
        }

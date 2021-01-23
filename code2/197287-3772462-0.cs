    class RandomSource
    {
        Dictionary<int, int> _dictionary = new Dictionary<int, int>();
        public int GetValue(int seed)
        {
            int value;
            if (!_dictionary.TryGetValue(seed, out value))
            {
                value = _dictionary[seed] = new Random(seed).Next();
            }
            return value;
        }
    }

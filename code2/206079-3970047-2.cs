        // Don't do this, it creates overhead for no reason
        // (a new state machine needs to be generated)
        public IEnumerable<string> GetKeys() 
        {
            foreach(string key in _someDictionary.Keys)
                yield return key;
        }
        // DO this
        public IEnumerable<string> GetKeys() 
        {
            return _someDictionary.Keys;
        }

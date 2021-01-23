    class DoubleStringList
    {
        SortedList<double, List<string>> _strings = new SortedList<double, List<string>>();
    
        public void Add(string str, double value)
        {
            List<string> list;
            if (!_strings.TryGetValue(value, out list))
            {
                _strings[value] = list = new List<string>();
            }
            list.Add(str);
        }
        public IEnumerable<KeyValuePair<double, string>> GetEntries()
        {
            var entries = from entry in _strings
                          from str in entry.Value
                          select new KeyValuePair<double, string>(entry.Key, str);
            return entries;
        }
    }

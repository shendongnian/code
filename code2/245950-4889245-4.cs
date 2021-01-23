    class MapKey
    {
        public LocaleM Locale { get; set; }
        public string Key { get; set; }
        public MapKey() { }
        public MapKey(string key, LocaleM localeM)
        {
            this.Locale = localeM;
            this.Key = key;
        }
    }
    class MapClass
    {
        private readonly Dictionary<string, string> _localToDefaultNameMap
            = new Dictionary<string, string>();
        private readonly Dictionary<MapKey, string> _defaultNameToLocalMap
            = new Dictionary<MapKey, string>();
        public void AddMapping(string defaultName, LocaleM locale, string localName)
        {
            _localToDefaultNameMap.Add(localName, defaultName);
            _defaultNameToLocalMap.Add(new MapKey(defaultName, locale), localName);
        }
        // maps from source name to target 
        public string Map(string sourceLocalName, LocaleM targetLocale)
        {
            string defaultName = _localToDefaultNameMap[sourceLocalName];
            MapKey mapKey = new MapKey();
            Dictionary<MapKey, string>.KeyCollection mapKeys = _defaultNameToLocalMap.Keys;
            foreach (var key in mapKeys)
            {
                if (key.Key == defaultName && key.Locale == targetLocale)
                {
                    mapKey = key;
                    break;
                }
            }
            if (_defaultNameToLocalMap.ContainsKey(mapKey))
            {
                string localName = _defaultNameToLocalMap[mapKey];
                return localName;
            }
            return null;
        }
    }

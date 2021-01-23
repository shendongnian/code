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
            if (_localToDefaultNameMap != null)
            {
                if (_localToDefaultNameMap.ContainsKey(sourceLocalName))
                {
                    string defaultName = _localToDefaultNameMap[sourceLocalName];
                    var mapKey = new MapKey();
                    foreach (var key in _defaultNameToLocalMap.Keys
                        .Where(key => key.Key == defaultName
                                      && key.Locale == targetLocale))
                    {
                        mapKey = key;
                        break;
                    }
                    if (_defaultNameToLocalMap.ContainsKey(mapKey))
                    {
                        var localName = _defaultNameToLocalMap[mapKey];
                        return localName;
                    }
                }
            }
            return null;
        }
    }

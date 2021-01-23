    class MapKey
    {
        public LocaleM Locale { get; set; }
        public string Key { get; set; }
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
            _defaultNameToLocalMap .Add(new MapKey(defaultName, locale), localName);
        }
        // maps from source name to target 
        public string Map(string sourceLocalName, LocaleM targetLocale)
        {
            string defaultName = _localToDefaultNameMap[sourceLocalName];
            string localName = _defaultNameToLocalMap[new MapKey(defaultName, targetLocale)];
            return localName;
        }
    }

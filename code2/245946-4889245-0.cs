    class MapKey
    {
        public LocaleM Locale { get; set; }
        public string Key { get; set; }
        // todo: ctor which takes locale and key as params
    }
    class Map
    {
        private readonly Dictionary<string, string> _localToDefaultNameMap = new ...
        private readonly Dictionary<MapKey, string> _defaultNameToLocalMap = new ...
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

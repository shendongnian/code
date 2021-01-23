    public static class GlobalData
    {
        private static readonly object _syncRoot = new object();
        private static Dictionary<string, int> _data;
        public static int GetItemsByTag(string tag)
        {
            lock (_syncRoot)
            {
                if (_data == null)
                    _data = LoadItemsByTag();
                return _data[tag];
            }
        }
        private static Dictionary<string, int> LoadItemsByTag()
        {
            var result = new Dictionary<string, int>();
            // Load the data from e.g. an XML file into the result object.
            return result;
        }
    }

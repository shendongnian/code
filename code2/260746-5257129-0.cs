    public static class StringCatalog
    {
        private static readonly Dictionary<string,int> m_CatalogMap;
        static StringCatalog()
        {
            m_CatalogMap = new Dictionary<string,int>();
            // use reflection to discover and assign unique IDs to string resources
            // ... LEFT AS AN EXCERCISE ...
        }
        public static int GetId( string stringResource )
        {
            return m_CatalogMap[stringResource];
        }
    }

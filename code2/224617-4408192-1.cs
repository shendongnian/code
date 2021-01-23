    [Serializable]
    internal class DataStoreContainer
    {
        public DataStoreContainer()
        {
            UserIDs = new List<int>();
        }
        public List<int> UserIDs { get; set; }
    }

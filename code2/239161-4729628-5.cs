    public class BIFDbManager : DbManager
    {
        public BIFDbManager() : base("Connection string name") { }
    
        public Table<DirectoryListing> DirectoryListings { get { return GetTable<DirectoryListing>(); } }
    }

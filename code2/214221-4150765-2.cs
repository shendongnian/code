    public class ItemsManager
    {
        #region Singleton implementation
        // Make constructor private to avoid instantiation from the outside
        private ItemsManager()
        {
        }
        // Create unique instance
        private static readonly ItemsManager _instance = new ItemsManager();
        // Expose unique instance
        public static ItemsManager Instance
        {
            get { return _instance; }
        }
    
        #endregion
    
        // instance methods
        // ...
    }
    
    public class HttpHelper
    {
        public ItemsManager ItemsManager { get { return ItemsManager.Instance; } }
    }

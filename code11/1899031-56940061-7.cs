    [Serializable]
    public class BOAT
    {
        public enum ListType
        {
            DefendInventory,
            AssistInventory,
            MiscInventory
        }
        public List<BlockScriptableObject> DefendInventory = new List<BlockScriptableObject>();
        public List<BlockScriptableObject> AssistInventory = new List<BlockScriptableObject>();
        public List<BlockScriptableObject> MiscInventory = new List<BlockScriptableObject>();
    
        public Dictionary<ListType, List<BlockScriptableObject>> ListByType;
    
        // Initialize the Dictionary in the default constructor
        public BOAT()
        {
            ListByType = new Dictionary<ListType, List<BlockScriptableObject>>
            {
                {ListType.DefendInventory, DefendInventory},
                {ListType.AssistInventory, AssistInventory},
                {ListType.MiscInventory, MiscInventory}
            };
        }
    }

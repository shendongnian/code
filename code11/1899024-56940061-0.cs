    public enum ListType
    {
        DefendInventory,
        AssistInventory,
        MiscInventory
    }
    [System.Serializable]
    public class BOAT
    {
        public List<BlockScriptableObject> DefendInventory = new List<BlockScriptableObject>();
        public List<BlockScriptableObject> AssistInventory = new List<BlockScriptableObject>();
        public List<BlockScriptableObject> MiscInventory = new List<BlockScriptableObject>();
        public Dictionary<ListType, List<BlockScriptableObject>> ListByType = new Dictionary<ListType, List<BlockScriptableObject>>
        {
            {ListType.DefendInventory, DefendInventory},
            {ListType.AssistInventory, AssistInventory},
            {ListType.MiscInventory, MiscInventory}
        }
    }

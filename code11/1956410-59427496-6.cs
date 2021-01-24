    // Note how for the limitation via where you still can use the generic type
    // which makes sure no other MonoBehaviour can be passed to TSelf by accident
    public class Inventory<TItem, TSelf> : Singleton<TSelf> where TItem : Item where TSelf : Inventory<TItem,TSelf>
    {
        public TItem reference;
    
        private void Awake()
        {
            if (!reference) reference = ScriptableObject.CreateInstance<TItem>();
        }
    }
    

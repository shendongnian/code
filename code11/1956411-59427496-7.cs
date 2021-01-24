    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        [SerializeField] private string _name;
    
        public string Name => _name;
    
        private void Awake()
        {
            _name = GetName();
        }
    
        protected virtual string GetName()
        {
           return nameof(Item);
        }
    }

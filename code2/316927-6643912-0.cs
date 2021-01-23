    partial class Fruit
    {
        private ICollection<Fruit> _children;
        private Fruit _parent;
        public String Name { get; set; }
        
        public Fruit()
        {
            _children = new FruitCollection(this);
        }
        public void AddFruits(IEnumerable<Fruit> fruits)
        {
            foreach (Fruit f in fruits)
                _children.Add(f);
        }
        public int NumberOfChildren
        {
            get { return _children.Count; }
        }
        public IEnumerable<Fruit> GetFruits()
        {
            return _children.ToList();
        }
    }

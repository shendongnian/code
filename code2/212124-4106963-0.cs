    public class Item
    {
        private List<Item> m_Dependencies = new List<Item>();
        protected AddDependency(Item _item) { m_Dependencies.Add(_item); }
        public Item()
        {
        }; // eo ctor
        public List<Item> Dependencies {get{return(m_Dependencies);};}
    } // eo class Item

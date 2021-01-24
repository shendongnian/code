    // not tested
    public class DataClass
    {
        public int ChangeCount => items.Sum(i => i.ItemChangeCount);
        public List<Item> items { get; set; }
    
        public class Item
        {
            public int ItemChangeCount { get; private set; } = 0;
            
            private readonly int _prop1;
            public int Prop1
            {
                get => prop1;
                set { _prop1 = value; ItemChangeCount++; }
            }
        }
    }

    class FooBar
    {
        private Hashtable ht = new Hashtable();
        public void AddToList(string ItemNo)
        {
            ht.Add(ItemNo, ItemNo);    
        }
    
        public void RemoveFromList(string ItemNo)
        {
            ht.Remove(ItemNo);
        }
    }

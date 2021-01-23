    class FooBar
    {
        private Hashtable ht = null; 
        public void AddToList(string ItemNo)
        {
            ht.Add(ItemNo, ItemNo);    
        }
    
        public void RemoveFromList(string ItemNo)
        {
            ht.Remove(ItemNo);
        }
    }

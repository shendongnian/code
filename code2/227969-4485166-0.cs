    class FooBar
    {
        private Hashtable ht = null; 
        public void AddToList(string ItemNo)
        {
            if (ht != null)
                ht = new Hashtable();
            ht.Add(ItemNo, ItemNo);    
        }
    
        public void RemoveFromList(string ItemNo)
        {
            if (ht != null)
                ht = new Hashtable();
    
            ht.Remove(ItemNo);
        }
    }

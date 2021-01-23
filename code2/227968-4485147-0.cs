    Hashtable ht = new Hashtable(); 
    public void AddTOList(string ItemNo)
    {
        ht.Add(ItemNo, ItemNo);
    }
    public void RemoveFromList(string ItemNo)
    {
        ht.Remove (ItemNo);
    }

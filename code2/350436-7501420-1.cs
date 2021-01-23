    [WebMethod]
    public DictionarySerializer GetHashTable()
    {
        Hashtable ht = new Hashtable();
        ht.Add(1, "Aaron");
        ht.Add(2, "Monica");
        ht.Add(3, "Michelle");
        return new DictionarySerializer (h1);
    }

    public string CollectionCount
    {
        get
        {
            if (MyCollection.Count <= 999)
                return MyCollection.Count.ToString();
            return "999+";
        }
    }

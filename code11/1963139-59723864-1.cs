    public void Add(MasterClass item)
    {
        int val = item.Stuff();
        switch (item)
        {
            case SubClass1 i: AddToDict(i, val); break;
            case SubClass2 i: AddToDict(i, val); break;
        }
    }

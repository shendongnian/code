    public Thing this[string index]
    {
        get
        {
             // get the item for that index.
             return YourGetItemMethod(index)
        }
        set
        {
            // set the item for this index. value will be of type Thing.
            YourAddItemMethod(index, value)
        }
    }

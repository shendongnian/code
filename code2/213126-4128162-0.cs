    public CustomObj this [string index]
    {
        get
        {
            return data[searchIdxByName(index)];
        }
        set
        {
            data[searchIdxByName(index)] = value;
        }
    }

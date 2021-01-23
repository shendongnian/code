    public object this[object index]
    {
        get
        {
            return this.Values[index];
        }
        set
        {                    
            this.Values[index] = value;
        }
    }

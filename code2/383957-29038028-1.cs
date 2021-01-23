    public string Property1 
    { 
        get
        {
            Contract.Ensures(Contract.Result<string>() != null);
            return this._property1;
        }            
        set
        {
            Contract.Requires(value != null);
            this._property1 = value;
        } 
    }

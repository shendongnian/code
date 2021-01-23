    public string ConnectionString
    {
        get
        {
            return this._ConnectionString;
        }
        set
        {
            this._ConnectionString = value != null ? value.ToLower() : null;
        }
    }

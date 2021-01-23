    private System.Guid _id;
    public System.Guid ID
    {
        get
        {
            if (_id == null || _id == Guid.Empty)
                _id = Guid.NewGuid();
            return _id;
        }
        set
        {
            _id = value;
        }
    }

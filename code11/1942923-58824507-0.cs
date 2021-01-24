    private DateTime? _someValue;
    [DataMember]
    public DateTime? SomeValue
    {
        get
        {
            return _someValue;
        }
        set
        {
            if (value.HasValue)
            {
                _someValue = value.Value.ToUniversalTime();
            }
        }
    }

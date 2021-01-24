    private string _m
    public string M
    {
        get => _m;
        set 
        {
            if (value != _m)
            {
                _m = value;
                if (string.IsNullOrEmpty(value))
                {
                    DoSomething(value);
                }
            }
        }
    }

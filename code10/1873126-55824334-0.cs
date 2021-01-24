    public int _LastName;
    public int LastName
    {
        get
        {
             get => _LastName;
        }
    
        set
        {
             _LastName= value.TrimAndReduce();
        }
    }

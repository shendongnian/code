    private List<T> _list;
    
    private List<T> MyT
    {
        get { return _list; }
        set
        {
            //Lock so only one thread can change the value at any given time.
            lock (_list)
            {
                _list = value;
            }
        }
    }

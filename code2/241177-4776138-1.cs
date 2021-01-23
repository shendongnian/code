    public Collection Collection
    {
        get { return _collection; }
        set
        {
            _collection = value;
            Thread.Sleep( 1000 ); // or some expensive real work
        }
    }

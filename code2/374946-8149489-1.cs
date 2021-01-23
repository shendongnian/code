    private int val = 10;
    public int Value
    {
        get { return val; }
        set { Interlocked.Exchange(ref val, value); }
    }

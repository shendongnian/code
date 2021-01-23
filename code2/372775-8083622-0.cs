    DateTime? _time = DateTime.Now;
    public DateTime? Time
    {
        set
        {
            _time = value;
        }
        get
        {
            return _time;
        }
    }
    public object GetSomeType(int num)
    {
        switch (num)
        {
            case 0:
                DateTime time = DateTime.Now;
                return time;
            case 1:
                int i = 5;
                return i;
            default:
                return null;
        }
    }
    private void Test()
    {
        this.Time = this.GetSomeType(0) as DateTime?;
        if(this.Time != null)
        {
            //proceed
        }
    }

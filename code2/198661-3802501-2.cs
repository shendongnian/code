    private int _Number;
    public string Number
    {
        get { return  _Number.ToString(); }
        set
        {
            if (!Int32.TryParse(value, out _Number))
            {
                throw new ApplicationException("Invalid integer number");
            }
        }
    }

    public virtual string DatabaseDoubleValue
    {
        get
        {
            return DoubleValue.ToString();
        }
        set
        {
            DoubleValue = double.Parse(value);
        }
    }

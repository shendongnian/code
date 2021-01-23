    public override object DataSource
    {
        get
        {
            return base.DataSource;
        }
        set
        {   
            if (!(value is IEnumerable<MyType>))
                throw new InvalidOperationException(...); // or ArgumentException
            base.DataSource = (IEnumerable<MyType>) value;
        }
    }

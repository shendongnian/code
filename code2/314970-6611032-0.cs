    public object DataSource
    {
        get { return myRepeater.DataSource; }
        set {
            if (value is IEnumerable) // or whatever your requirement is, if needed
                myRepeater.DataSource = value;
            else
                throw new NotSupportedException("DataSource must be an IEnumerable type");
        }
    }

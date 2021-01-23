    public string FieldValue
    {
        get
        {
            return _fieldValue;
        }
        set
        {
            _fieldValue = value;
            Trace.WriteLine( string.Format("Received value '{0}'.", value ) );
        }
    }

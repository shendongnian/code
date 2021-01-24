    public int FieldCount => _values.Length;
    public string GetString(int ordinal) => _values[ordinal];
    public object GetValue(int ordinal)=> _values[ordinal];
   
    //What if we have more values than expected?
    public int GetValues(object[] values)
    {
        if (_values.Length > 0)
        {
            Array.Copy(_values, values,_values.Length);
            return _values.Length;
        }
        return 0;
    }

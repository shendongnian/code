    
    private object _MyObject;
    public object GetMyObject() {
        return _MyObject;
    }
    public void SetMyObject(object value) {
        if (value == DbNull.Value)
            value = null;   
        _MyObject = value;
    }

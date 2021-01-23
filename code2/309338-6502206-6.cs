    
    private DateTime? _MyDate;
    public object GetMyDate() {
        return _MyDate
    }
    public void SetMyDate(object value) {
        if (value == null || value == DbNull.Value)
            _MyDate = null;   
        else
            _MyDate = (DateTime?)value;
    }

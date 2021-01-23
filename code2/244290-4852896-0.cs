    public override bool IsValid(object value)
    {
        if(value==null)
           return false;
        string field = value.Tostring();
        if (String.IsNullOrEmpty(field))
            return false;
        return true;
    }

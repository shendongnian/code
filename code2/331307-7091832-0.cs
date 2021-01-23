    if (value is string)
    {
        string sVal = value.ToString();
        //handle as string...
    }
    else if (value is DateTime)
    {
        DateTime dtVal = (DateTime)value;
        //handle as DateTime...
    }
    else
    {
        //some other type
    }

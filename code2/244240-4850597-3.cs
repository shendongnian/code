    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return false;
        }
        string str = value as string;
        if (str != null)
        {
            return (str.Trim().Length != 0);
        }
        return true;
    }

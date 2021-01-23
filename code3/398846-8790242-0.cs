    public int CompareTo(object obj)
    {
        if (obj is int)
        {
            return myIntField.CompareTo((int)obj);
        }
        return 0;
    }

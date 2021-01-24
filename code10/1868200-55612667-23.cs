    public bool IsDBNull(int i)
    {  
        //Covers the "null" case too, when `Length` is 0
        if (i>_values.Length-1)
        {
            return true;
        }
        return _inner.IsDBNull(i);
    }

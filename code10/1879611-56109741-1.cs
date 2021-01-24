    public string ToBigEndianString(DateTime? date)
    {
        string returnValue = null;
        if(date != null)
        {
            returnValue = date.Value.ToString("yyyy-MM-dd");
        }
        return returnValue;
    }

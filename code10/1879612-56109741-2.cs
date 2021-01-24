    public string ToBigEndianString(string ukDate)
    {
        DateTime? d = ToDateTime(ukDate);
        return ToBigEndianString(d);
    }

    public int someBadFunction()
    {
        Contract.Ensures(Contract.Result<int>() != 0);
        if(....)
        {
           if(....) return 2;
           if(....) return 8;
        }
        return 3;
    }

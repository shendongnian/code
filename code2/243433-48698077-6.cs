    public void Test()
    {  
        Guid NewG = Guid.NewGuid();
        Guid EnryptedGuid = Utility.EncodeInt24InGUID(NewG, Num);
        uint RestoredUint = Utility.DecodeInt24FromGUID(EnryptedGuid);
    }

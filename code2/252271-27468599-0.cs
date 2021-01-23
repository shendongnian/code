    [WebMethod]
    public ServiceReturnCodes SetMsg(List<Guid> Ids, DateTime processDateTime)
    {
        List<Guid> _Ids = new List<Guid>();
        _Ids.AddRange(Ids);
        BL.SetMsg(_Ids, DateTime.Now);   
    }

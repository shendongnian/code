    [HttpGet]
    [Route("api/Pen/ByPropertyIdList")]
    public IEnumerable<Pen> ListByPropertyIdList([FromUri] Int32[] propIds)
    {
        Boolean? deleted = false;
        IEnumerable< Pen > p = logic.ListByPropertyIdList(propIds, deleted).AsEnumerable();
        return p;
    }

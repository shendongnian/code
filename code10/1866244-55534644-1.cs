    //GET api/issues/5
    [HttpGet("{id}")]
    public Issue GetByRoute([FromRoute(Name="id")] int id)
    {
        IssueService service = new IssueService();
        return service.GetIssueById(id);
    }   
     
    [HttpGet()]
    public Issue GetByQuery([FromQuery(Name="severity")] int severityId)
    {
       IssueService service = new IssueService();
       return service.GetIssueById(severityId);
    }   

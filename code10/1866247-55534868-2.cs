    // GET api/issues/severity/5
    [Route("severity/{severity}")]
    [HttpGet()]
    public IEnumerable<Issue> GetBySeverity(int severity)
    {
        IssueService service = new IssueService();
        return service.GetIssuesBySeverity(severity);
    }
    // GET api/issues/5
    [HttpGet("{id}")]
    public Issue Get(int id)
    {
        IssueService service = new IssueService();
        return service.GetIssueById(id);
    }   

    // GET api/issues/severity?severity=5
    [HttpGet("severity")]
    public IEnumerable<Issue> GetBySeverity([FromQuery] int severity)
    {
        IssueService service = new IssueService();
        return service.GetIssuesBySeverity(severity);
    }
    // GET api/issues?id=5
    [HttpGet()]
    public Issue Get([FromQuery] int id)
    {
        IssueService service = new IssueService();
        return service.GetIssueById(id);
    } 

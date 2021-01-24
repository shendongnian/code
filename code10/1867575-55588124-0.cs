    [HttpGet]
    [Route("api/Compare/GetCompared")]
    public IHttpActionResult GetCompared(string TeamProject, string Project, string branch)
    {
          return Ok(_BranchesCompareService.BrancheCompare(TeamProject, Project, branch));
    }

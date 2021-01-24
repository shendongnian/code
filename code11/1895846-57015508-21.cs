    // TOOD: Move roles to a constants/globals
    [Authorize(Policy = Policies.HasRoleInTenant, Roles = "admin")]
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return new string[] { "value1", "value2" };
    }

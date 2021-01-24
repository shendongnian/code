    [ResourceAuthorize("values", ResourceRoles = "reader")]
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return new string[] { "value1", "value2" };
    }

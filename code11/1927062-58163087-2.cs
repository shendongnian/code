    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "High Time1", "High Time2", "High Time3", "High Time4", "High Time5" };                    
        }

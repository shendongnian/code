    [HttpGet("v1/users/{id}")]
    public async Task<ActionResult> GetUser(string id)
    {
        return Ok(new { id = id });
    }
    [HttpGet("v1/users/me")]
    public async Task<ActionResult> GetCurrentUser()
    {
        return Ok(new { id = "current" });
    }

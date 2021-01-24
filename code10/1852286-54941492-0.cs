    [HttpPost("Create")]
    public async Task<ActionResult<string>> Create([FromBody] TestPayload value)
    {
        return Ok("");
    }

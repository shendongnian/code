    [HttpGet("GetValue")]
    public async Task<IActionResult> GetValue([FromQuery] IDictionary<string, string> id)
    {
         return Ok();
    }

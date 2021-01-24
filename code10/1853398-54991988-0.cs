    [Authorize]
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> C2dSend()
    {
        // Request.Method is POST here
        return Ok();
    }

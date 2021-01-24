    [Authorize]
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> C2dSend(YourModel blah)
    {
        // model will be populated automatically from request body
        return Ok();
    }

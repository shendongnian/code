    [HttpGet]
    [Route("LongRunningProcess")]
    public async Task<IActionResult> LongRunningProcess(CancellationToken cancellationToken)
    {
        // Dummy long operation
        await Task.Delay(60000, cancel);
        return Ok();
    }

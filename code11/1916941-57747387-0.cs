    [HttpGet]
    [Route("LongRunningProcess")]
    public async Task<IActionResult> LongRunningProcess(CancellationToken cancellationToken)
    {
        // Dummy long operation
        await Task.Run(() =>
            {
                for (var i = 0; i < 60; i++)
                {
                    if (cancel.IsCancellationRequested)
                        break;
                    Task.Delay(1000).Wait();
                }
            });
        return Ok();
    }

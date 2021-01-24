    [HttpGet("lengthy")]
    public async Task<IActionResult> Lengthy()
    {
        await _progressHubContext
            .Clients
            .Group(ProgressHub.GROUP_NAME)
            .SendAsync("taskStarted");
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(200);
            Debug.WriteLine($"progress={i + 1}");
            await _progressHubContext
                .Clients
                .Group(ProgressHub.GROUP_NAME)
                .SendAsync("taskProgressChanged", i + 1);
        }
        await _progressHubContext
            .Clients
            .Group(ProgressHub.GROUP_NAME)
            .SendAsync("taskEnded");
        return Ok();
    }

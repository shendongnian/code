    public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
    {
        var referer = req.Headers["Referer"].ToString();
        log.LogInformation("Referer is "+referer);
        return new OkObjectResult($"");
    }

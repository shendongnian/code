    public IActionResult Index()
    {
        if (_environment.IsDevelopment())
        {
            // only show in development
            return View();
        }
        _logger.LogInformation("Homepage is disabled in production. Returning 404.");
        return NotFound();
    }

    [Route("Create")]
    public IActionResult Create()
    {
        this.logger.LogInformation("Creating a league");
        return View();
    }
    [Route("Create")]
    [HttpPost]
    public IActionResult Create(League league)
    {
        this.logger.LogInformation("Create button clicked!");
        return this.RedirectToAction("Index");
    }

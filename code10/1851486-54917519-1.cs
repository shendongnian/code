    [Authorize(Policy = "CanAccessGroup")]
    public IActionResult About()
    {
        return View();
    }

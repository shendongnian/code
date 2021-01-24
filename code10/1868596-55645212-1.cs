    [Authorize(Roles = "Admin")]
    public IActionResult About()
    {
        var result = User.IsInRole("Admin");
        return View();
    }

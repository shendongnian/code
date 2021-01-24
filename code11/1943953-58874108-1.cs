    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpGet]
    [RequireRequestValue("caption")]
    public IActionResult Register(string caption)
    {
        ViewData["Title"] = "Registration";
        ViewBag.caption = caption;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register()
    {
        return RedirectToAction("Register", "Account", new { caption = "This user is currently configured with a password" });
    }

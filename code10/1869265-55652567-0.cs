    [HttpGet]
    public ActionResult Login()
    {
        if (User.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Dashboard");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel req)
    {
        return View(req);
    }

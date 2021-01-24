    [HttpGet]
            public async Task<IActionResult> Index()
            {
                if (true)// implement cookie policy
                    return RedirectToAction("Login");

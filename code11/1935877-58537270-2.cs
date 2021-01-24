    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromQuery(Name = "returnUrl")] string returnUrl)
    {
        if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                    return RedirectToAction("index", "home");
                else
                    return LocalRedirect(returnUrl);
    }

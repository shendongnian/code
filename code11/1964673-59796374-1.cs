    [Authorize]
    public IActionResult Login(string returnUrl)
    {
        if (string.IsNullOrWhiteSpace(returnUrl))
            return LocalRedirect($"~/");
        return LocalRedirect($"~{returnUrl}");
    }

    public void OnGet(string returnUrl = null, int acclevel = 1)
    {
        HttpContext.Session.SetInt32("AccountLevel", acclevel);
        ReturnUrl = returnUrl;
    }
    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        int accountLevel = HttpContext.Session.GetInt32("AccountLevel");
        ...
    }

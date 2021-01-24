    public IActionResult OnGet()
    {
        return Page();
    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var emailAddress = Request.Form["emailaddress"];
        // do something with emailAddress
    }

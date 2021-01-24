    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var emailAddress = Request.Form["emailaddress"];
        // do something with emailAddress
    }

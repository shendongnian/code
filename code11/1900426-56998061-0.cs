    private void Page_Load(object sender, EventArgs e)
    {
        // Check whether the current request has been
        // authenticated. If it has not, redirect the 
        // user to the new page.
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("mysite.cpm");
        }
    }

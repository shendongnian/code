    /// <summary>
    /// this event occurs just after user is authenticated
    /// </summary>
    void Application_AuthorizeRequest(object sender, EventArgs e)
    {
        // check if user is authenticated
        if (User.Identity.IsAuthenticated)
        {
            // checking page extension
            switch (System.IO.Path.GetExtension(Context.Request.Url.AbsoluteUri.ToLower()))
            {
                case ".bmp":
                case ".gif":
                case ".jpg":
                case ".jpe":
                case ".jpeg":
                case ".png":
                case ".css":
                case ".js":
                case ".txt":
                case ".swf":
                    // don't redirect, these requests may required in many cases
                    break;
                default:
                    // checking if request is not for ChangePassword.aspx page
                    if (!Context.Request.Url.AbsoluteUri.ToLower().Contains("/changepassword.aspx"))
                    {
                        Context.Response.Redirect("~/ChangePassword.aspx");
                    }
                    break;
            }
        }
    }

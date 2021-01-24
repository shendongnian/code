    if (groupNames.Contains("Admins") || groupNames.Contains("Mgrs"))
        {
            return;
        }
        else
        {
            Response.Redirect("~/AccessDenied.aspx");
        }

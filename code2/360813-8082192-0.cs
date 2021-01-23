        System.Web.HttpContext.Current.Response.Redirect("http://<server>/_layouts/SignOut.aspx");
    }
    else
    {
        System.Web.HttpContext.Current.Application[System.Web.HttpContext.Current.User.Identity.Name] = System.Web.HttpContext.Current.Request.UserHostAddress;
    }

    string str = "~/User" + "/" + Page.User.Identity.Name + "/" + Page.User.Identity.Name + ".aspx";
    string path = Server.MapPath(str);
    if (File.Exists(path)) 
    {
        Response.Redirect(str);
    }
    else
    {
        Response.Redirect("Page.aspx");
    }

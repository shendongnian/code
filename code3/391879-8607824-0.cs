    if (Request.Cookies["CurrentID"] == null)
    {
        Response.Cookies.Add(new HttpCookie("CurrentID", "0"));
        return 0;
    }
    return Request.Cookies["CurrentID"].Value.AsID();

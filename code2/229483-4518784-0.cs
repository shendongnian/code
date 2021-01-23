    if (Request.Cookies["test"] != null &&!string.IsNullOrWhiteSpace(Request.Cookies["test"].Value))
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
    }

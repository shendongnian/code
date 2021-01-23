    protected void Page_PreInit(object sender, EventArgs e)
    {
        var theme = Session["Theme"] as string;
        if (theme != null) 
        {
            Page.Theme = theme;
        }
    }

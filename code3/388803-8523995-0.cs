    protected override void OnLoad( EventArgs e )
    {
        Session["foo"] = "bar";
        string valueFromSession = Session["foo"].ToString();
    }

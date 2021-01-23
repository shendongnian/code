    protected void btnSessionStart_Click(object sender, EventArgs e)
    {
        Guid Session_id = Guid.NewGuid();
        Session["SessionID"]
        = Session_id.ToString();
    
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        if (Session["SessionID"] != null)
            txtSession.Text =
            Session["SessionID"].ToString();
        else
            txtSession.Text =
            "Session has expired";
    }
    protected void btnGO_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default2.aspx");
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        CheckSession();
    }
    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    
    private void CheckSession()
    {
        if (Session["SessionID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    
    }

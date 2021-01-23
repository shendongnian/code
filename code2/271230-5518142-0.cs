    protected void Page_Load(object sender, EventArgs e)
    {
        Control c = Page.Master.FindControl("MasterBody");
        if (c != null)
        {
            c.ID = "Page1";
        }
    }

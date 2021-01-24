    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack && !string.IsNullOrEmpty(txtSearch.Text))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "reFilter", "myFunction()", true);
        }
    }

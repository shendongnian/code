    protected void Page_Load(object sender, EventArgs e)
    {
        ddlDatabase.DataSource = dbList.GetDbList();
        ddlDatabase.DataBind();
        Response.Buffer = true;
        if (Session["Error"] != null)
                ErrorMessage();
        if (Session["Datasource"] != null)
            ddlDatabase.SelectedValue = Session["Datasource"].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gv.DataSource = [YourDataSource];
            gv.DataBind();
        }
    }
    protected void Clicker(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Link")
        {
            Response.Redirect(e.CommandArgument.ToString());
        }
    }
    protected void gv_DataBinding(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hlink = e.Row.FindControl("hlink") as HyperLink;
            hlink.NavigateUrl = ((Person)e.Row.DataItem).NavUrl;
            hlink.Text = ((Person)e.Row.DataItem).NavUrl;
            hlink.Target = "_blank";
            LinkButton lnkButton = e.Row.FindControl("lnkButton") as LinkButton;
            lnkButton.Text = ((Person)e.Row.DataItem).NavUrl;
            lnkButton.CommandName = "Link";
            lnkButton.CommandArgument = ((Person)e.Row.DataItem).NavUrl;
        }
    }

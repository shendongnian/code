    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
    {
        ViewState["CurrentValue"] = Your Value;
    }
    }
    protected void btnSubmit_click(object sender, EventArgs e)
    {
    if (NewValue==  ViewState["CurrentValue"].ToString())
    {
        lblmsg.Text = "value is not changed..";
    return;
    }
    else
        lblmsg.Text = "value is changed..";
    }

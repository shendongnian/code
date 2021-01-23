    protected override Page_Load(object sender, EventArgs e)
    {
        if( !IsPostBack)
        {
            DataTable tbl = GetData();
            lstData.DataSource = tbl;
            lstData.DataBind();
            // store in viewstate
            ViewState["data"] = tbl;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable tbl = (DataTable)ViewState["data"];
    }

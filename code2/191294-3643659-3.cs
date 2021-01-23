    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gv.DataSource = list;
            gv.DataBind();
        }
    }
    
    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {
        // Delete Operation.
    }

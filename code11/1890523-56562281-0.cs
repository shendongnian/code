    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DropDownList1.DataSource = db.ComplaintTypes.ToList();
            DropDownList1.DataTextField = "ct_Name";
            DropDownList1.DataBind();
    
            cboCpriority.DataSource = db.ComplaintPriorities.ToList();
            cboCpriority.DataTextField = "cp_Desc";
            cboCpriority.DataBind();
        }
    }

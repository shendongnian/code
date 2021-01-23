    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndexChanged += new System.EventHandler(this.On_SelectedIndexChanged);
    
        if (!IsPostBack)
        {
            DataClassesDataContext datacontext = new DataClassesDataContext();
            DropDownList1.DataSource = datacontext.GetAllDepartments(false);
            DropDownList1.DataBind();
        }
    
    
    }

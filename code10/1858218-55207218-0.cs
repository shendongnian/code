    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            empList.DataSource = EmpRepository.GetDepartments();
            empList.DataBind();
        }
    }

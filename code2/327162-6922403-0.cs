    protected void gvEmp_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DemoGrid.EditIndex = e.NewEditIndex;
        BindGrid();
        DropDownList dropdown = gvEmp.Rows[e.NewEditIndex].FindControl("DropDownList1") as DropDownList;
        BindDropDown(dropdown);
    }
    private void BindDropDown(DropDownList temp)
    {
        string connectionString = "Password=priyal;User ID=priyal;Initial Catalog=asptest;Data Source=dbsvr";
        string query = "select deptno from employees";
        DataSet dataset = new DataSet("Employees");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                adapter.Fill(dataset);
            }
        }
        temp.DataSource = dataset;
        temp.DataTextField = "deptno";
        temp.DataValueField = "deptno";
        temp.DataBind();
    }

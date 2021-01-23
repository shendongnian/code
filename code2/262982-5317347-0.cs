        SqlConnection Conn = new SqlConnection(MyConnectionString);
        Conn.Open();
        SqlDataAdapter Adapter = new SqlDataAdapter("Select * from Employees", Conn);
        DataTable Employees = new DataTable();
        Adapter.Fill(Employees);
        GridView1.DataSource = Employees;
        GridView1.DataBind();

     conn.Open();
     SqlCommand cmd2 = new SqlCommand("SELECT p.ProjectName AS ProjectName, p.Status FROM   Project p, Company c WHERE c.CompanyID = p.CompanyID AND c.CompanyID = 3", conn);
    cmd2.CommandType = CommandType.Text;
    SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd2);
    DataSet ds2 = new DataSet();
    sqlAdapter.Fill(ds2);
    Gridview1.DataSource = ds2;
    Gridview1.DataBind();
    conn.Close();

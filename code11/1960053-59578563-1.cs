        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=PC\\SQLEXPRESS;Initial Catalog=AlvisDB;Persist Security Info=True;User ID=sa;Password=pass";
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT CustomerName FROM Customers";
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            con.Close();
        }
just add this code in your existing code
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            protected void Page_Load(object sender, EventArgs e)
            {
                con.ConnectionString = "Data Source=PC\\SQLEXPRESS;Initial Catalog=AlvisDB;Persist Security Info=True;User ID=sa;Password=pass";
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT CustomerName FROM Customers";
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable finalTable = new DataTable();
                if (ds.Tables.Count > 0)
                {
                    int i = 1;
                    DataTable firstTable = ds.Tables[0];
                    foreach (DataRow row in firstTable.Rows)
                    {
                        if (i == 5)
                        {
                            firstTable.NewRow();
                            i = 0;
                        }
                        finalTable.Rows.Add(row);
                        i++;
                    }
                }
                Repeater1.DataSource = finalTable;
                Repeater1.DataBind();
                con.Close();
            }

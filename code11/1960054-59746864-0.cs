        protected void Page_Load(object sender, EventArgs e)
                    {
                        con.ConnectionString = "Data Source=PC\\SQLEXPRESS;Initial Catalog=AlvisDB;Persist Security Info=True;User ID=sa;Password=pass";
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT CustomerName FROM Customers";
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adp.Fill(ds);
        if (ds != null && ds.Tables[0].Rows.Count > 4)  
        {  
            for (int i = 1; i < ds.Tables[0].Rows.Count - 1; i++)  
            {  
                var row = ds.Tables[0].NewRow();  
                row["CustomerName"] = string.Empty;  
                            
                if (i % 5 == 0)  
                {  
                    ds.Tables[0].Rows.InsertAt(row,i);  
                    ds.AcceptChanges();  
                }  
            }  
        }
    Repeater1.DataSource = finalTable;
                    Repeater1.DataBind();
                    con.Close();
    }

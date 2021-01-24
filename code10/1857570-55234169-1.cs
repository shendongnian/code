	using (SqlConnection sqlconn = new SqlConnection(@"Data Source=DESKTOP-IIBSL6N;Initial Catalog=sales_management;Integrated Security=True"))   
    {  
        sqlconn.Open();  
        SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Customer WHERE Name = N'" + this.customergrid.SelectedRows + "' ", sqlconn);  
        sqlcmd.ExecuteNonQuery();  
        DataTable dtbl = new DataTable();  
        SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);  
        adapter.Fill(dtbl);  
        foreach (DataRow dr in dtbl.Rows)  
        {  
            accountnumtxtbox.Text = dr["acount_name"].ToString();  
            phonetxtbox.Text = dr["phone_number"].ToString();  
            officenumtxtbox.Text = dr["office_number"].ToString();  
            addresstxtbox.Text = dr["Address"].ToString();  
        }  
        sqlconn.Close();  
    }  

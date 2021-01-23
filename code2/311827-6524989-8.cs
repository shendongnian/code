    using (SqlConnection cn = new SqlConnection("connection string to yer database"))
    {
        SqlCommand cm = new SqlCommand("exec sp_databases", cn);
        SqlDataReader rdr;
        cn.Open();
        rdr = cm.ExecuteReader();
        if (rdr.HasRows())
        {
           while (rdr.Read())
           {
               listBox1.Items.Add(rdr["DATABASE_NAME"].ToString());                
           }
        }
        rdr.Close();
    }

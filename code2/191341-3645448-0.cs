    public void Sql_Connection(string queryString)
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RBConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand(queryString, conn);
        conn.Open();
       SqlDataReader rdr = cmd.ExecuteReader();
       while(rdr.Read())
       {
           lblDescription.Text = rdr.GetString(0); 
       }
        rdr.Close();
        conn.Close();
    }

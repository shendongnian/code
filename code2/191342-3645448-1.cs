    public void Sql_Connection(string queryString)
    {
         using(SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings"RBConnectionString"].ConnectionString))
         {
            using(SqlCommand cmd = new SqlCommand(queryString, conn))
            {
               conn.Open();
               using(SqlDataReader rdr = cmd.ExecuteReader())
               {
                   while(rdr.Read())
                   {
                       lblDescription.Text = rdr.GetString(0); 
                   }
               }
            }
    
         }
    }

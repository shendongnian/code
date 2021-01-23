    // define your query
    string query = "SELECT YourField FROM dbo.YourTable WHERE ID = 1";
    using(SqlConnection conn = new SqlConnection("......"))
    using(SqlCommand cmd = new SqlCommand(query, conn))
    {
       conn.Open();
 
       using(SqlDataReader rdr = cmd.ExecuteReader())
       {
           if(rdr.Read())
           {
              string fieldValue = rdr.GetString(0);
           }
       }
       conn.Close();
    }

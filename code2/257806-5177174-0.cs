    string cteQuery = ";WITH yourCTE AS (SELECT .... FROM :... WHERE.....) SELECT * FROM yourCTE";
    using(SqlConnection _con = new SqlConnection(connectionString))
    using(SqlCommand _cmd = new SqlCommand(cteQuery, _con))
    {
       // provide parameters to the query, if needed
       _con.Open();
      
       using(SqlDataReader rdr = _cmd.ExecuteReader())
       {
           while(rdr.Read())
           {
              // grab your data from the data reader here
           }
           rdr.Close();
       }
       _con.Close();
    }

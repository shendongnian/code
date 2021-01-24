    using (var con = new SqlConnection(...))
    {
       con.Open();
       using (var con2 = new SqlConnection(...))  
       {
         con2.Open(); //con is not available, as it's open and in-use so a new connection will be opened and enlisted
       }
    }

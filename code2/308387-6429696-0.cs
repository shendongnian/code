    SqlDataReader rdr = null;
    SqlConnection conn = new SqlConnection( /*Connection string*/ );
    
    SqlCommand cmd  = new SqlCommand("select * from  Books", conn);
    conn.Open();
    rdr = cmd.ExecuteReader();
    while (rdr.Read())
    {
       string bookTitle= (string)rdr["Book Title"];
       string bookAuthor = (string)rdr["Book Author"];
     
       Console.Write("{0,-25}", bookTitle);
       Console.Write("{0,-20}", bookAuthor );
    
       Console.WriteLine();
    }

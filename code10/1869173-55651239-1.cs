    using(MySqlConnection con = new MySqlConnection(connString)) // --> First connection opening here
    {
    con.Open(); // --> And second connection opening here.
      using(MySqlCommand cmd = new MySqlCommand(...))
      {
         ...
      }
    con.Close(); // --> Second is closing here
    } // --> First one is closing here

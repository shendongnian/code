    var csb = new SqlConnectionStringBuilder(yourConnectionString);
    csb.ConnectTimeout = 5;
    try
    {
      using(var c = new SqlConnection(csb.ToString())
      {
        c.Open();
      }
    }
    catch(Exception ex)
    {
      Show the exception to user
    }
    go on your own

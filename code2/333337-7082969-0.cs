    public class ExampleRepository1
    {
      private SqlConnection _conn;
      public ExampleRepository(SqlConnection conn)
      {
        _conn = oConnection;
      }
    }
    public class ExampleRepository2
    {
      private SqlConnection _conn;
      public ExampleRepository2(SqlConnection conn)
      {
        _conn = conn;
      }
    }
    // Share the database connection:
    var conn = new SqlConnection(...);
    try
    {
      conn.Open();
      // You could also begin a transaction here
      // Use conn.BeginTransation()
      var repo1 = new ExampleRepository1(conn);
      var repo2 = new ExampleRepository2(conn);
      repo1.Find(...);
      repo2.Delete(...)
    }
    finally
    {
      conn.Close();
    }
    
    

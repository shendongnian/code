    static class dbConnection
    {      
      //Connection to database 
      private static string con = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=MLQ7024; Integrated Security=TRUE"
    
      public static string Con
      {
        get
        {
          return con;
        }
      }
    }

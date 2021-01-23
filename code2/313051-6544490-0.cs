    String doSomething()
    {
      SqlConnection conn;
      
      try {
        conn = new SqlConnection();
    
        // SQL stuff
    
        return result;
      }
      catch(Exception ex) { AddToLog(ex);  }
      finally {
        if (conn != null)
          conn.Dispose();
      }
      return null;
    }

    Try
    {
    // your code that you assign and execute the SQl
    
    }
    catch (SQLException sqlex)
    {
      try 
      {
        //try to do the rollback here.. don't always assume the commit or rollback will work
      }
      catch (Your SQL Exception ex)
      {
      }
    }

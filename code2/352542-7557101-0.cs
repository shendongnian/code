    try 
    {
      throw new Exception("This is a test.");
    }
    catch ( Exception ex )
    {
      Console.WriteLine(ex);
      Console.WriteLine(ex.Message);
    }

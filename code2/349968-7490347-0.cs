    public void log(Action methodToExecute)
    {
        try
        {
          Console.WriteLine("Logging...");
          methodToExecute();
        }
        finally
        {
          Console.WriteLine("End Logging...");
        }
    
    }

    void FixedUnalterableMethod()
    {
        try
        {
            throw new Exception("Exception 1"); //line 12.
        }
        finally
        {
            throw new Exception("Exception 2"); //line 16.
        }
    }
    void Method1()
    {
		bool CatchException(Exception ex)
		{
			//Log...
			Console.WriteLine(ex.ToString());
			return true;
		}
		try
		{
			FixedUnalterableMethod(); //line 24.
		}
		catch (Exception ex) when (CatchException(ex))
		{
			//do something with the lastest exception
		}
	}

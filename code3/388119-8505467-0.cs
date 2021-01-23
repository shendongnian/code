    private static void HandleExceptions(Action action)
    {
    	try
    	{
    	   action();
    	}
    	catch (Exception1 e)
    	{
    	}
    	catch (Exception2 e2)
    	{
    	}
    	  ...
    	catch (ExceptionN eN)
    	{
    	}
    }

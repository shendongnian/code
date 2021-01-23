    try
    {
        // code causing TargetInvocationException
    }
    catch (Exception e)
    {
        if (e.InnerException != null)
        {
    	string err = e.InnerException.Message;
        }
    }

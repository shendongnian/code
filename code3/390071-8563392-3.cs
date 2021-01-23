    private TR HandleException<TR>(Func<TR> action)
    {
        try
        {
            return action();
        }
        catch (ServiceException ex)
        {
            ModelState.Merge(ex.Errors);
        }
        catch (Exception e)
        {
            Trace.Write(e);
            ModelState.AddModelError("", "Database access error: " + e.Message);
        }
    
    	return default(TR); // null for reference types
    }

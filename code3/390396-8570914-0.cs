    protected void log(Exception ex)
    {
		ServiceException se = ex as ServiceException;
        if (se != null)
            ModelState.Merge(se.Errors);
        else
        {
            Trace.Write(ex);
            ModelState.AddModelError("", "Database access error: " + ex.Message);
        }
    }

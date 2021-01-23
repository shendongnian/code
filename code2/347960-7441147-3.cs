    try 
    {
        some code 
    }
    catch(Exception ex)
    {
        Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
    }

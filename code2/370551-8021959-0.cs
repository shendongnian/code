    try
    {
       SqlDataReader reader = cmd.ExecuteReader();
    }
    catch(Exception ex)
    {
       string errorMessage = String.Format(CultureInfo.CurrentCulture, 
                             "Exception Type: {0}, Message: {1}{2}", 
                             ex.GetType(),
                             ex.Message,
                             ex.InnerException == null ? String.Empty : 
                             String.Format(CultureInfo.CurrentCulture,
                                          " InnerException Type: {0}, Message: {1}",
                                          ex.InnerException.GetType(),
                                          ex.InnerException.Message));
    
      System.Diagnostics.Debug.WriteLine(errorMessage);
    }

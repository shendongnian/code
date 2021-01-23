    try
    {
        //code here
    }
    catch (Exception ex)
    {
        if (ex.GetBaseException() is iAnywhere.Data.SQLAnywhere.SAException)
        {
            // log or handle known exception
        }
        else
        {
            // log unexpected exception
        } 
    }

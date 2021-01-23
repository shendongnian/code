    try
    {
       transfer.TransferData();
    }
    catch (Exception ex)
    {
        var theRealExceptionTypeName = ex.GetType().Name;
    }

    int ReturnValue = 0;
    Context dc = null;
    try
    {
        dc = new CrystalCommon.MainContext();
        ReturnValue = (dc.tblHelpCentreQuestions.Where(c => c.awaitingSupportResponse == true).Count());
    }
    finally
    {
        if(dc != null)
            dc.Dispose();
    }
    return ReturnValue;

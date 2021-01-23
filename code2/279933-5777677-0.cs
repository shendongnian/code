    void DoLogic1(...)
    {
        try
        {
            CalculateSomeData(...);
            SaveCalculatedData(...);
            DoRequestToExternalService(...);
        }
        catch(Exception ex)
        {
            LogException(...)
            throw;
        }
    }

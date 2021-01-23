    try
    {
        throw new MyCustomException();
    }
    catch (OracleException ex)
    {
        // Handle me...
    }
    catch (MyCustomException)
    {
        // Important: NOT `throw ex` (to preserve the stach trace)
        throw;
    }
    catch (Exception ex)
    {
        // Handle me...
    }

    try
    {
        // Do whatever database operation here
    }
    catch (SqlException ex)
    {
        // Log the exception
        _logService.Log(ex);
        // Throw something else to the user
        throw new ExceptionWithCode("XYZ_1234", "Unable to connect");
    }
    catch (Exception ex)
    {
        // Log the exception
        _logService.Log(ex);
        // Throw something else to the user
        throw new ExceptionWithCode("ABC_9876", "Unable to connect");
    }

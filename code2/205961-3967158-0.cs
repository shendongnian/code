    catch (UpdateException ex)
    {
        SqlException innerException = ex.InnerException as SqlException;
        if (innerException != null && innerException.Number == ??????)
        {
            // handle exception here..
        }
        else
        {
            throw;
        }
    }

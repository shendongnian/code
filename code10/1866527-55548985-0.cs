    try
    {
        Data.CreateUserAndAccount.ExecuteProcedure(accountName, firstName, lastName, email, password);
        return String.Empty;
    }
    catch (DataException procedureError)
    {
        SqlException sqlError = (SqlException)procedureError.InnerException;
        string result = IdentifyError(sqlError);
        return result;
    }

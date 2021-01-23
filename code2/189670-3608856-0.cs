    /// <summary>
    /// Calls matching process error code on response.Code
    /// </summary>
    /// <param name="response">Actually will be of type Response or extend it</param>
    /// <returns>true for successful response, false otherwise</returns>
    private static bool ProcessErrorCode(object response)
    {
        Func<Type, Func<object, string>> process = ...;
        var errCode = process(response.GetType())(response);
        if (errCode != "Ok")
        {
            LogErrorCode("Operation resulted in error code:" + errCode);
        }
        return errCode == "Ok";
    }

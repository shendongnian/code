    try
    {
        //your code here...
    }
    catch (Exception exception) when (exception.InnerException is InvalidOperationException)
    {
        var exceptionMessage = "ExecuteNonQuery requires an open and available Connection";
        if (exception.Message.Contains(exceptionMessage) || exception.InnerException.Message.Contains(exceptionMessage))
        {
            //handle it...
        }
    }

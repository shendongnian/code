    void MyApiFunction()
    {
        try
        {
            // do data manipulation
        }
        catch(MyCustomException ex)
        {
            _log.ErrorFormat(ex.ErrorMessage, ex.InnerEx);
            AlertMailer.SendAlertMessage(ex.ErrorMessage, ex.InnerEx);
        }
    }

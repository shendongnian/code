    public void MyMethod(string input)
    {
        try {
            Process(input);
        } catch (Exception ex) {
            LogExceptionTree(ex);
        }
    }
    private void LogExceptionTree(Exception exception)
    {
        _logger.log(exception);
        if(exception.InnerException != null)
            LogExceptionTree(exception.InnerException);
    }

    public void MyMethod(string input)
    {
        try {
            Process(input);
        } catch (Exception ex) { // <- (2) Attempting to view ex here would show null
            _logger.log(ex);
            LogInner(ex.InnerException);
        }
    }
    private void LogInner(Exception ex)
    {
        _logger.log(ex); // <- (1) NullReferenceExeption thrown here
        if(ex.InnerException != null)
            LogInner(ex.InnerException);
    }

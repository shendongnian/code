    public int CreateOrder(string currency, double amount)
    {
        try
        {
            throw new InvalidOperationException("Cannot call this operation!");
        }
        catch (Exception e)
        {
            // This sanitizes the message and throws a new Exception
            Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionPolicy.
                HandleException(e, "SanitizeAndThrow");
        }
        return 0;
    }

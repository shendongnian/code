    public void Intercept(IInvocation invocation) {
        try {                
            invocation.Proceed();
        }
        catch (Exception e) {
            // log the exception e
            throw;
        }
    }

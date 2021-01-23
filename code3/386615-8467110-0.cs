    public void TryAllImplementations<TService>(
        IEnumerable<TService> services,
        Action<TService> operation,
        Action<Exception> exceptionHandler = null)
    {
        int dummy = 0;
        TryAllImplementations(
            services, 
            svc => { operation(svc); return dummy; },
            exceptionHandler);
    }
    public TReturn TryAllImplementations<TService, TReturn>(
        IEnumerable<TService> services, 
        Func<TService, TReturn> operation,
        Action<Exception> exceptionHandler = null)
    {
        foreach (var svc in services)
        {
            try
            {
                return operation(svc);
            }
            catch (Exception ex)
            {
                if (exceptionHandler != null)
                    exceptionHandler(ex);
            }
        }
        throw new ProgramException("All implementations have failed.");
    }

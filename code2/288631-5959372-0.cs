    public static Action FailOnException(this Action original)
    {
        return () => 
        { 
            try { original(); } 
            catch(Exception ex) { Environment.FailFast("Unhandled exception", ex); }
        };
    }

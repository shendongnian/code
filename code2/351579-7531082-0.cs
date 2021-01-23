    public void LogErrors(string message, params string[] parameters)
    {
        LogErrors(string.Format(message, parameters));
    }
    public void LogErrors(string message)
    {
        // Use methods with *no* formatting
    }

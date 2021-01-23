    private void ThrowAndLog<TException>(string message, params object[] args) 
        where TException : Exception, new()
    {
        message = string.Format(message, args);
        Logger.Error(message);
        throw (TException)typeof(TException).GetConstructor(
            new[] { typeof(string) }).Invoke(new object[] { message });
    }

    public void ExecuteAndLog(Func<T> func, string startMessage, string endMessage) {
        Status(startMessage);
        var result = func;
        Status(endMessage, result);
    }

    public static void Log(this ILog source, string message)
    {
        source.Log(message, null);
    }
    
    public static void Log(this ILog source, string message, param object[] args)
    {
        // Assuming a static class as mentioned by @IAbstract
        Logger.Log(message, args);
    }

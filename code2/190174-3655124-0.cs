    public static void LogMessage(params string[] messages)
    {
        string message = messages.Join("\r\n");
        Logger.Write(newmessage, "DebugCategory", 2, 4000, TraceEventType.Information, "Message"););
    }

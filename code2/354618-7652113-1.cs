    public static string RemoveControlChars(this string s)
    {
        return Regex.Replace(s, @"\p{Cc}", "");
    }
    public static void TraceEvent(this TraceSource trace, 
        TraceEventType eventType, MyEvtEnum eventId, string message)
    {
        trace.TraceEvent(eventType, (int)eventId, message.RemoveControlChars());
    }

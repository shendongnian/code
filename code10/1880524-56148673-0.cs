    private static readonly object s_lock = new object();
    public static void UpdateAskDate(this HttpContext context, DateTime AskDate)
    {
        lock (s_lock) //only allow one thread at a time to enter here
            context.Items["AskDate"] = AskDate;
    }

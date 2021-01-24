    private static void InitializeSystemEvents()
    {
        var timerId = SystemEvents.CreateTimer(1);
        SystemEvents.KillTimer(timerId);
    }

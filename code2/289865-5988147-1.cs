    [Flags]
    public enum LogType
    {
        Warning = -2,
        Error = -1,
        Info = 0,
        EruCtorDtor = 1,
        Notifications = 2,
        CommunicationWithAOT = 4,
        ExecutedOrder = 8,
        ERUInfo = 16,
        DebugLog = 32,
    }

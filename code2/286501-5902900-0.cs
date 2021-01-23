    [FlagsAttribute]
    public enum TransactionStatus
    {
        New = 0,
        Submitted = 1,
        PendingStatus = 2,
        Accepted = 4,
        // (...)
    }
    [FlagsAttribute]
    public enum PendingStatus
    {
        PendingA = 256,
        PendingX = 512,
        PendingY = 1024,
    }

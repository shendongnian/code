    /// <summary>
    /// Represent all available status for Transaction
    /// </summary>
    [Flags]
    public enum TransactionStatus
    {
        New = 0,
        Submitted = 1,
        PendingStatus = 2,
        Accepted = 4,
        Rejected = 8,
        InProgress = 16,
        Completed = 32,
        Failed = 64,
        Canceled = 128
    }
    
    /// <summary>
    /// Represent all available pending status for Transaction
    /// </summary>
    [Flags]
    public enum PendingStatus
    {
        PendingA = 0,
        PendingX = 1,
        PendingY = 2
    }  
    // Example
    var MyTransactionStatus = Accepted & PendingA;
    // How to check ?
    if (MyTransactionStatus & PendingA == PendingA) ...

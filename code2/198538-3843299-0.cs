    public interface ILeaseTransaction
    {
        int ID { get; }
        DateTime Date { get; }
        decimal Amount { get; }
        ILeaseTransactionVoid Void { get; } // This throws an error
    }

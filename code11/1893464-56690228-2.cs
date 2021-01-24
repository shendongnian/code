    public class Transaction
    {
        public Transaction(string transactionId, string name, decimal amount)
        {
            TransactionId = transactionId;
            Name = name;
            Amount = amount;
        }
        public string TransactionId { get; }
        public string Name { get; }
        public decimal Amount { get; }
    }
    public interface ITransactionProcessor
    {
        // returns an output code
        string ProcessTransaction(Transaction transaction);
    }

    public class Entry
    {
       public Entry(decimal amount, DateTime date, TransactionType transactionType, bool cleared)
       {
          Amount = amount;
          Date = date;
          TransactionType = transactionType;
          Cleared = cleared;
       }
    
       public decimal Amount { get; set; }
       public DateTime Date { get; set; }
       public TransactionType TransactionType { get; set; }
       public bool Cleared { get; set; }
    
    }

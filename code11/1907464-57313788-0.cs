    public class Transaction {
      public int TransactionID { get; set; }
      public int ProductID { get; set; }
      public virtual Product Product { get; set; }
    }

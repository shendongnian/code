    public class Transaction
    {
        public Transaction()
        {
            Items = new List<TransactionItems>();
        }
        //some other properties
        public ICollection<TransactionItems> Items {get; set;}
    }

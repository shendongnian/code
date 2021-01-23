    [Table]
    public interface IInvoice
    {
        [Column]
        public int RecordID {get; set;}
    
        [Column]
        public DateTime RecordDate {get; set;}
    }
    
    [Table]
    public class ProductPurchase : IInvoice, IOrder
    {  }

    public interface IInvoice
    {
        public int RecordID {get; set;}
    
        public DateTime RecordDate {get; set;}
    }
    
    [Table]
    public class ProductPurchase : IInvoice, IOrder
    {  }

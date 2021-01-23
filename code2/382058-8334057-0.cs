    public class PurchaseOrder
    {
         public int POID {get;set;}
         public int OrderID {get;set;}
         public int VendorID {get;set;}
         public IEnumerable<Order> Orders {get;set;}
    
         public IEnumerable<Order> MatchingOrders {
             get {
                return this.Orders.Where(o => o.VendorId == this.VendorId);
             }
         }
    }

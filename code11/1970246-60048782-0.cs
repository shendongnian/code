c#
public class SalesOrder : ModelBase
{
    public string ordertitle { get; set; }
    
    [ForeignKey(nameof(Supplier))]
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
}
And you can add a collection of Sales orders to the suppliers.
c#
public class Supplier : ModelBase
{
    public string CompanyName { get; set; }
    public string ContactPerson { get; set; }
    public string Phone { get; set; }
    public string Street { get; set; }
    public string Zip { get; set; }
    public string City { get; set; }
    public int Discount { get; set; }
    public ICollection<SalesOrder> SalesOrders { get; set; }
}
Then, if you would like to get the Sales orders with the supplier, you can use the Include() action when you query the supplier. 
c#
var supplier = _context.Suppliers.Include(s => s.SalesOrders).Single(s => s.Id == id);

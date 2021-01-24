public class Status
{
    public int Id { get; set; }
    public string Status { get; set; }
}
public class Order
{
    public Guid Id  { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } 
    public int StatusId { get; set; }
    public virtual Status status { get; set; }
} 
Then you can do ```Order.Status.Status``` for each row while displaying

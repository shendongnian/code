c#
class NotTuple
{
    public int PropInt { get; set; }
    public string PropString { get; set; }
    public float PropFloat { get; set; }
}
(Because they have different type!)
Therefore, when you do 
c#
.Select(x => (
       x.ItemDescription,
       x.Quantity,
       x.UnitPrice,
       x.Price = TotalValue((int)x.Quantity, (float)x.UnitPrice)
    ))
you create an `IEnumerable<(string, int, float)>`, not a `IEnumerable<Item>`. Later when you call `.ToList()`, the IEnumerable is consumed and materialized to a `List<(string, int, float)>`, which is not interchangeable with `List<Item>`.

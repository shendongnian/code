public class Body
{
    public string ShipmentId{get; set;}
    public DateTime PickupDate{get; set;}
    public IList<int> OrderNumbers{get; set;}
}
public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Body Body { get; set; }
}

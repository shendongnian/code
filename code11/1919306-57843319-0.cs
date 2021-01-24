c#
public class DomainEventContainer
{
    public ObjectId Id { get; set; }
    public string Type { get; set; }
    public string EventData { get; set; }
}
And then based on the value of DomainEventContainer.Type, you could deserialize EventData into your desired type.

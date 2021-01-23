    public interface IDomainEvent
    {
       Guid EventId { get; }
       Guid TriggeredByEvent { get; }
       DateTime Created { get; }
    }
    
    public class OrderCancelledEvent : IDomainEvent
    {
       Guid EventId { get; set; }
       Guid TriggeredByEvent { get; set; }
       DateTime Created { get; set; }
       // And now for the specific bit
       int OrderId { get; set; }
    }

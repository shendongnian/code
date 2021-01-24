c#
// Canonical Data Model
namespace CDM {
public interface ICommand { }
public interface IEvent { }
public class CustomerInfo {
    public Guid Id { get; set; }
    // notice here the CDM uses the two separate properties for the first and last name
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public class LineItemData {
    public Guid ProductId { get; set; }
    public Quantity Quantity { get; set; }
    public Money ListPrice { get; set; }
}
public class PlaceOrderCommand : ICommand {
    public CustomerInfo CustomerInfo { get; set; }
    public IReadOnlyList<LineItemData> LineItems { get; set; }
}
public class OrderPlacedEvent : IEvent {
    public Guid OrderId { get; set; }
    public IReadOnlyList<LineItemData> LineItems { get; set; }
}
} // end Canonical Data Model namespace
// Order Service Internals
// the name is done this way to differentiate between the CDM
// and the internal command, do not use it this way into production
public class LineItem {
     
    // the internal one includes the OrderId { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public Quantity Quantity { get; set; }
    public Money ListPrice { get; set; }
}
public class PlaceOrderInternalCommand {
    public Guid CustomerId { get; set; }
    public string CustomerFullName { get; set; } // a single full name here
    public IReadOnlyList<LineItemData> LineItems { get; set; }
}
public class Event { }
public class OrderPlacedInternalEvent : Event {
    public Guid OrderId { get; set; }
    public IReadOnlyList<LineItem> { get; set; }
}
// this is part of the infrastructure, received messages and translates/transforms
//them from the external CDM to the internal model.
// This is the input/receiving part of the service
public class CommandDispatcher {
    public void Dispatch(ICommand cmd) {
        // here we will use a MessageTranslator, check PatternsUsed section
        var translator = TranlatorsRegistry.GetFor(cmd);
        var internalCommand = translator.Translate(cmd);
        Dispatch(internalCommand);
    }
}
public class CommandHandler {
    public void Handle(PlaceOrderInternlCommand cmd) {
        // this will create the OrderCreated event
        var order = CreateOrder(cmd); 
        // this will save the OrderCreated event
        OrderRepository.Save(order);
    }
}
// Another part of the infrastructure that publishes events.
// This is the output/sending part of the service
public class EventPublisher {
    public void Publish(Event event) {
        // another usage of the MessageTranslator pattern, this time on events
        var translator = EventTranslatorRegisty.GetFor(event);
        var cdmEvent = translator.Translate(event);
        // publish to kafka or whatever you are using
        PubilshToMessageMiddleware(cdmEvent);
    }
}
Patterns Used:
[Canonical Data Model](https://www.enterpriseintegrationpatterns.com/patterns/messaging/CanonicalDataModel.html)
[MessageTranslator](https://www.enterpriseintegrationpatterns.com/patterns/messaging/MessageTranslator.html)
[CommandMessage](https://www.enterpriseintegrationpatterns.com/patterns/messaging/CommandMessage.html)
[EventMessage](https://www.enterpriseintegrationpatterns.com/patterns/messaging/EventMessage.html)

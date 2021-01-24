	public interface IEventHandlerFactory 
	{
	  IEventHandler<TEvent>[] GetHandlers<TEvent>(TEvent event) where TEvent : IEvent;
	}	
	public class EventDispatcher 
	{
	  private readonly IEventHandlerFactory factory;
	  public EventDispatcher(IEventHandlerFactory factory)
	  {
		this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
	  }
	  public void Dispatch<TEvent>(TEvent @event) where TEvent : IEvent
	  {
		foreach(var handler in this.factory.GetHandlers(@event))
		{
		  handler.Handle(@event);
		}
	  }
	}

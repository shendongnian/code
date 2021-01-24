csharp
public class EventBus
{
    // Change the type of values to Action<object>
    private readonly Dictionary<Type, Action<object>> _handlers = new Dictionary<Type, Action<object>>();
    public void Register<T>(IEventHandler<T> eventHandler)
    {
        // When you store the lookup, create the handler.
        _handlers[typeof(T)] = CreateHandler(eventHandler);
    }
    private Action<object> CreateHandler<T>(IEventHandler<T> eventHandler)
    {
        // The lambda that's created here is an Action<object> and the cast assumes that
        // someData is of the correct type.
        return someData => eventHandler.Handle((T)someData);
    }
    public void Handle(object @event)
    {
        var eventType = @event.GetType();
        var eventHandler = _handlers[eventType];
        // The dictionary gives back an Action<object> that you can call directly.
        eventHandler(@event);
    }
}

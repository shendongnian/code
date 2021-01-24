csharp
internal interface IHandler
{
	void Subscribe(Func<Action<object>, Guid> subscribe);
	void Unsubscribe(Action<Guid> action);
}
public abstract class Handler<T> : IHandler
{
	private Guid _subscriptionToken;
	public virtual void Subscribe(Func<Action<object>, Guid> subscribe)
	{
		var action = new Action<T>(HandleNonAsync);
		_subscriptionToken = subscribe(Convert(action));
	}
	public virtual void Unsubscribe(Action<Guid> action)
	{
		action(_subscriptionToken);
	}
	public abstract Task HandleAsync(T eventType);
	private void HandleNonAsync(T eventType)
	{
		HandleAsync(eventType).GetAwaiter().GetResult();
	}
	private Action<object> Convert(Action<T> myActionT)
	{
		if (myActionT == null) return null;
		else return new Action<object>(o => myActionT((T)o));
	}
}

csharp
public abstract class TemplateScriptEvent<TEventArgs> : ScriptEvent
    where TEventArgs : EventArgs
{
	public event EventHandler<TEventArgs> Event;
  	protected virtual void OnEvent(TEventArgs e) => Event?.Invoke(this, e);
}
**Abstract "event" for any delegate types:**
If you really want to use any delegate type, then the closest solution you can do is something like this:
csharp
public abstract class TemplateScriptDelegate<TDelegate, TResult> : ScriptEvent
    where TDelegate : Delegate
{
    // this is a simple property rather than an event, but allows +=/-= for concrete delegate types
    // (and also simple assignments).
	public TDelegate Event { get; set; }
	
    // you must implement this in a more concrete derived type
	protected abstract TResult OnEvent();
}
// To be able to use this you need a derived type for each delegate types (which of course,
// can have type arguments for return value and parameters).
// For example, you can have a derived type for Func<T> delegates:
public class TemplateScriptFunc<TResult> : TemplateScriptDelegate<Func<TResult>, TResult>
{
	protected override TResult OnEvent() => Event.Invoke();
}

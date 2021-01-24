c#
public interface IMyComponentContext
{
  T Resolve<T>();
}
public class ComponentContextWrapper : IMyComponentContext
{
  private readonly IComponentContext _autofacContext;
  public ComponentContextWrapper(IComponentContext autofacContext)
  {
    _autofacContext = autofacContext;
  }
  public T Resolve<T>()
  {
    return this._autofacContext.Resolve<T>();
  }
}
It's going to be a lot. Then...
- Create a wrapper for `IComponentContext`.
- Create the wrappers for all the registration bits.
- Implement basically already what you have up there - except you'll need to wrap/unwrap as needed. Something like:
c#
// In the place where you actually register your delegates, you'll have
// to provide wrappers for your clients:
builder.Register((c, p) => delegate1(new ComponentContextWrapper(c)));
If I haven't already made it clear, I have a pretty strong opinion that this is a Bad Idea. It's a lot of work and unless there's really some potential need to move away from Autofac, there's no real payoff for maintaining the abstractions, testing them, etc. However, that's what you'll need to do if you want to keep that separation. Good luck!

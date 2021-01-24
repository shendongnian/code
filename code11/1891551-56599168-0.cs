 c#
public class LazyMyServiceProxy : IMyService
{
    private readonly Lazy<MyService> lazy;
    public LazyMyServiceProxy(Lazy<MyService> lazy) => this.lazy = lazy;
    public void SomeMethod() => this.lazy.SomeMethod();
}
You can use this proxy using the following Autofac registrations.
 c#
builder.RegisterType<MyService>();
builder.RegisterType<LazyMyServiceProxy>().As<IMyService>();

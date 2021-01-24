 c#
public class AspNetUserContext : IUserContext
{
    User CurrentUser => (User)HttpContext.Current.Session[USER_CONTEXT];
}
This allows this ASP.NET-specific `IUserContext` implementation to be registered as follows:
 c#
container.RegisterInstance<IUserContext>(new AspNetUserContext());
Of course, the previous does not solve the problem in your Windows Service, but the previous does lay the foundation for the solution.
For the Windows Service you need a custom implementation (an adapter) as well:
 c#
public class ServiceUserContext : IUserContext
{
    User CurrentUser { get; set; }
}
This implementation is much simpler and here `ServiceUserContext`'s `CurrentUser` property is a writable property. This solves your problem elegantly, because you can now do the following:
 c#
// Windows Service Registration:
container.Register<IUserContext, ServiceUserContext>(Lifestyle.Scoped);
container.Register<ServiceUserContext>(Lifestyle.Scoped);
// Code in the new Thread:
using (container.BeginLifetimeScope())
{
    .....
    var userContext = container.GetInstance<ServiceUserContext>();
    
    // Set the user of the scoped ServiceUserContext
    userContext.CurrentUser = GetUserContext(message);
    
    var handler = container.GetInstance<IHandleMessages<SomeMessage>>();
    
    handler.Handle(message);
    
    .....
}
Here, the solution is, as well, the separation of creation of object graphs and the use of runtime data. In this case, the runtime data is provided to the object graph after construction (i.e. using `userContext.CurrentUser = GetUserContext(message)`).
  [1]: https://blogs.cuttingedge.it/steven/posts/2015/code-smell-injecting-runtime-data-into-components/

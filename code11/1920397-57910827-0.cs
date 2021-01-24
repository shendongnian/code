c#
public interface IAsyncRepository<T> where T : BaseEntity
{
}
public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
{
    public EfRepository(MyDbContext dbContext)
    {
    }
}
public interface IDomainEventDispatcher
{
}
public interface IDomainEventHandler
{
}
public abstract class DomainEventHandler<T> : IDomainEventHandler where T: BaseDomainEvent
{
}
public class OrderCreatedEventHandler : DomainEventHandler<OrderCreatedEvent>
{
    public OrderCreatedEventHandler(IAsyncRepository<EmailTemplate> emailTemplate)
    {
    }
}
public class OrderDispatchedEventHandler : DomainEventHandler<OrderDispatchedEvent>
{
    public OrderDispatchedEventHandler(IAsyncRepository<NotificationRecipient> notificationRecipientRepository)
    {
    }
}
public class DomainEventDispatcher : IDomainEventDispatcher
{
    public DomainEventDispatcher(IEnumerable<IDomainEventHandler> eventHandlers)
    {
    }
}
public class MyDbContext : DbContext
{
    public MyDbContext(IDomainEventDispatcher domainEventDispatcher)
    {
    }
}
The methods in there, the implementations of the interfaces, etc. aren't really important.
Next thing to do is remove Autofac from the equation. Autofac is basically a fancy way of calling `new SomeClass()` and wiring up dependencies.
**What would you do if you had to make one of these yourself? You can't.**
Let's drop the interfaces and use the concrete class names:
- `EfRepository<T>` needs `MyDbContext`
- `MyDbContext` needs `DomainEventDispatcher`
- `DomainEventDispatcher` needs all of the handlers, BUT
- All of the handlers need `EfRepository<T>`
You couldn't new any of these things up if you tried because there is a circular dependency.
There are several ways to unwind this sort of thing and all require some design
1. **Break things up.** Sometimes classes have dependencies that are only used by one method. Break that into two classes. This adds some separation of responsibility and makes it possible to use the half that _doesn't_ cause a circular dependency in the chain. Another thing to think about might be that the event dispatcher could use a different repository or repository type that doesn't cause the circular dependency.
2. **Use method parameters.** For example, what if the event dispatcher took a repository in as a parameter on the various methods that require it rather than having it as a dependency? It may not be as pretty, but it'd break the circle.
3. **Use public settable properties.** Instead of making the repository a constructor parameter on the dispatcher, you could have a public "Repository" property that gets set. You can create the dispatcher then set the property later. No circle during construction.
**The important thing is to think about what you'd do if you had to manually create it.** Autofac can't work around it if it's not something you could manually work around yourself.
[Autofac has docs on circular dependencies](https://autofaccn.readthedocs.io/en/latest/advanced/circular-dependencies.html) that show how to use property injection to break a circular dependency. [There are also docs on property and method injection](https://autofac.readthedocs.io/en/latest/register/prop-method-injection.html) that can help and show examples.

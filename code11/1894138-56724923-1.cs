c#
using System;
public abstract class AggregateRoot
{
    public void ApplyChange(IEvent @event)
    {
        Apply(@event); // how to call this method?
    }
    protected abstract void Apply(IEvent e);
}
public class Customer : AggregateRoot
{
    protected override void Apply(IEvent e)
    {
        if (e is CustomerCreatedEvent)
        {
            Console.WriteLine("CustomerCreatedEvent");
        }
    }
}
public class Product : AggregateRoot
{
    protected override void Apply(IEvent e)
    {
        if (e is ProductCreatedEvent)
        {
            Console.WriteLine("ProductCreatedEvent");
        }
    }
}
public interface IEvent
{
}
public class CustomerCreatedEvent : IEvent
{
}
public class ProductCreatedEvent : IEvent
{
}
But please note, it has it downsides as:
- methods needs to non-private
- the should have the same parameter type for Apply. (IEvent) - so I've added the type checks.
## Option 2: abstract method and generic AggregateRoot
Another option is to make AggregateRoot generic for the type IEvent, e.g. something like this.
using System;
public abstract class AggregateRoot<TEvent>
where TEvent : IEvent
{
    public void ApplyChange(TEvent @event)
    {
        Apply(@event); // how to call this method?
    }
    protected abstract void Apply(TEvent e);
}
public class Customer : AggregateRoot<CustomerCreatedEvent>
{
    protected override void Apply(CustomerCreatedEvent e)
    {
        Console.WriteLine("CustomerCreatedEvent");
    }
}
public class Product : AggregateRoot<ProductCreatedEvent>
{
    protected override void Apply(ProductCreatedEvent e)
    {
        Console.WriteLine("ProductCreatedEvent");
    }
}
public interface IEvent
{
}
public class CustomerCreatedEvent : IEvent
{
}
public class ProductCreatedEvent : IEvent
{
}
Note I've changed also ApplyChange in this case.
If those things won't solve your problem, please elaborate what you are trying to archive, otherwise this will be a [XY problem](http://xyproblem.info/)

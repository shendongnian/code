 c#
public void SendCommand<T>(T command) where T : ICommand
{   
    using (var scope = services.CreateScope())
    {
        var handler = scope.ServiceProvider
            .GetRequiredService<ICommandHandler<T>>();
        handler.Handle(command);
    }
}
This is, of course, not what your question is about. Removing the generic type argument allows a more dynamic way of dispatching commands, which is useful when command types are not known at compile time. In that case you can use dynamic typing, as follows:
 c#
public void SendCommand(ICommand command)
{   
    using (var scope = services.CreateScope())
    {
        var commandType = command.GetType();
        var handlerType =
            typeof(ICommandHandler<>).MakeGenericType(commandType);
        dynamic handler = scope.ServiceProvider
            .GetRequiredService(handlerType);
        handler.Handle((dynamic)command);
    }
}
Notice two things here:
1. The resolved handler is stored in a `dynamic` variable. Its `Handle` method is, therefore, a dynamic invocation where `Handle` is resolved at runtime.
2. Since `ICommandHandler<{commandType}>` does not contain a `Handle(ICommand)` method, the `command` argument needs to be cast to a `dynamic`. This instructs the C# binding that it should look for *any* method named `Handle` method with one single argument that matches the supplied runtime type of `command`.
This option works pretty well, but there are two downsides to this 'dynamic' approach:
1. The lack of compile-time support will let any refactoring to the `ICommandHandler<T>` interface get unnoticed. This is probably not a huge problem, as it can easily be unit tested.
2. Any decorator that gets applied to any `ICommandHandler<T>` implementation needs to ensure that it is defined as a public class. The dynamic invocation of the `Handle` method will (weirdly) fail when the class is internal, as the C# binder won't spot that the `Handle` method of the `ICommandHandler<T>` interface is publically accessible.
So instead of using dynamic, you can also use good old generics, similar to your approach:
 c#
public void SendCommand(ICommand command)
{   
    using (var scope = services.CreateScope())
    {
        var commandType = command.GetType();
        var handlerType =
            typeof(ICommandHandler<>).MakeGenericType(commandType);
        object handler = scope.ServiceProvider.GetRequiredService(handlerType);
            
        var handleMethod = handlerType.GetMethods()
            .Single(s => s.Name == nameof(ICommandHandler<ICommand>.Handle));
            
        handleMethod.Invoke(handler, new[] { command });
    }
}
This prevents the problems with the previous approach, as this will surfive refactoring of the command handler interface, and it can invoke the `Handle` method even if the handler is internal.
On the other hand, it does introduce a new problem. In case a handler throws an exception, the call to `MethodBase.Invoke` will cause that exception to be wrapped in an `InvocationException`. This can cause trouble up the call stack, when the consuming layer catches certain exceptions. In that case the exception should first be unwrapped, which means `SendCommand` is leaking implementation details to its consumers.
There are several ways to fix this, for instance:
 c#
public void SendCommand(ICommand command)
{   
    using (var scope = services.CreateScope())
    {
        var commandType = command.GetType();
        var handlerType =
            typeof(ICommandHandler<>).MakeGenericType(commandType);
        object handler = scope.ServiceProvider.GetRequiredService(handlerType);
            
        var handleMethod = handlerType.GetMethods()
            .Single(s => s.Name == nameof(ICommandHandler<ICommand>.Handle));
        
        try
        {        
            handleMethod.Invoke(handler, new[] { command });
        }
        catch (InvocationException ex)
        {
            throw ex.InnerException;
        }
    }
}
Downside of this approach, however, is that you lose the stack trace of the original exception, as this exception is rethrown (which is typically not a good idea). So instead, you can do the following:
 c#
public void SendCommand(ICommand command)
{   
    using (var scope = services.CreateScope())
    {
        var commandType = command.GetType();
        var handlerType =
            typeof(ICommandHandler<>).MakeGenericType(commandType);
        object handler = scope.ServiceProvider.GetRequiredService(handlerType);
            
        var handleMethod = handlerType.GetMethods()
            .Single(s => s.Name == nameof(ICommandHandler<ICommand>.Handle));
        
        try
        {        
            handleMethod.Invoke(handler, new[] { command });
        }
        catch (InvocationException ex)
        {
            ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
        }
    }
}
This makes use of .NET 4.5's `ExceptionDispatchInfo` which is also available under .NET Core 1.0 and up and .NET Standard 1.0.
As a last option, you can also, instead of resolving `ICommandHandler<T>`, resolve a wrapper type that implements a non-generic interface. This makes the code types safe, but does force you to register the extra generic wrapper type. This goes as follows:
 c#
public void SendCommand(ICommand command)
{   
    using (var scope = services.CreateScope())
    {
        var commandType = command.GetType();
        var wrapperType =
            typeof(CommandHandlerWrapper<>).MakeGenericType(commandType);
        var wrapper = (ICommandHandlerWrapper)scope.ServiceProvider
            .GetRequiredService(wrapperType);
            
        wrapper.Handle(command);
    }
}
public interface ICommandHandlerWrapper
{
    void Handle(ICommand command);
}
public class CommandHandlerWrapper<T> : ICommandHandlerWrapper
    where T : ICommand
{
    private readonly ICommandHandler<T> handler;
    public CommandHandlerWrapper(ICommandHandler<T> handler) =>
        this.handler = handler;
    
    public Handle(ICommand command) => this.handler.Handle((T)command);
}
// Extra registration
services.AddTransient(typeof(CommandHandlerWrapper<>));

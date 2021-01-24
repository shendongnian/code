 c#
public class ICommandContext
{
    Type RootRequest { get; }
}
This abstraction allows you to check what the type is of the root request that is currently running. You can use this abstraction inside your decorator:
 c#
public class ActivationMessageWithoutLinkFactory : IMessageFactory 
{
    private readonly ICommandContext _context;
    private readonly IMessageFactory _messageFactory;
    public ActivationMessageWithoutLinkFactory(
        ICommandContext context,
        IMessageFactory messageFactory)
    {
        _context = context;
        _messageFactory = messageFactory;
    }
    public IMessage CreateMessage(MessageData messageData)
    {
        if (_context.RootRequest == typeof(ExternalAddUser))
        {
            // Begin decorated stuff
            var message = _messageFactory.CreateMessage(messageData);
            // End decorated stuff
            
            return message;
        }
        else
        {
            return _messageFactory.CreateMessage(messageData);
        }
    }
}
Inside your Composition Root, you can now create an `ICommandContext` implementation and a `ICommand<,>` decorator that can manage this context:
 c#
public class CommandContext : ICommandContext
{
    public Stack<Type> Requests = new Stack<Type>();
    
    public Type RootRequest => Requests.First();
}
public class ContextCommandDecorator<TRequest, TResponse> : ICommand<TRequest, TResponse>
{
    private readonly CommandContext _context;
    private readonly ICommand<TRequest, TResponse> _decoratee;
    public ContextCommandDecorator(
        CommandContext context,
        ICommand<TRequest, TResponse> decoratee)
    {
        _context = context;
        _decoratee = decoratee;
    }
    public TResponse Execute(TRequest request)
    {
        _context.Push(typeof(TRequest));
        
        try
        {
            return _decoratee.Execute(request);
        }
        finally
        {
            _context.Pop();
        }
    }
}
Finally, you can add the following three registrations to your application:
 c#
container.Register<ICommandContext, CommandContext>(Lifestyle.Scoped);
container.Register<CommandContext>(Lifestyle.Scoped);
container.RegisterDecorator(typeof(ICommand<,>), typeof(ContextCommandDecorator<,>));

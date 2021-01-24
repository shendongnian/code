     public abstract class CommandHandlerBase
        {
            protected static readonly Dictionary<Type, CommandHandlerBase> _handlers = new Dictionary<Type, CommandHandlerBase>();
    
            protected abstract void HandleCommand<TCommand>(TCommand command) where TCommand: ICommand;
    
            public static void Handle<TCommand>(TCommand command) where TCommand : ICommand
            {
                if (_handlers.TryGetValue(typeof(TCommand), out var handler))
                {
                    handler.HandleCommand(command);
                }
            }
        }
    
        public abstract class CommandHandlerBase<TCommandHandlerBase, TCommand> : CommandHandlerBase
            where TCommandHandlerBase : CommandHandlerBase<TCommandHandlerBase, TCommand>, new() where TCommand : ICommand
        {
            public static void Register()
            {
                var type = typeof(TCommand);
                _handlers[type] = new TCommandHandlerBase();
            }
    
            protected override void HandleCommand<T>(T command) => Handle((TCommand) (object) command);
    
            public abstract void Handle(TCommand command);
        }

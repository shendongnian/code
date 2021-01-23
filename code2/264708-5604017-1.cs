    class GenericCommandProcessor : ICommandProcessor
    {
        private readonly IDictionary<Type, object> _handlers = 
            new Dictionary<Type, object>();
    
        public void Register<TCommand>(ICommandHandler<TCommand> handler) 
            where TCommand : ICommand
        {
            IList<ICommandHandler<TCommand>> handlers = GetHandlers<TCommand>();
            handlers.Add(handler);
        }
    
        public void Process<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            IList<ICommandHandler<TCommand>> handlers = GetHandlers<TCommand>();
    
            foreach (var commandHandler in handlers)
            {
                commandHandler.Handle(command);
            }
        }
    
        private IList<ICommandHandler<TCommand>> GetHandlers<TCommand>()
        {
            Type commandType = typeof(TCommand);
            
            object untypedValue;
            if (!_handlers.TryGetValue(commandType, out untypedValue))
            {
                untypedValue = new List<ICommandHandler<TCommand>>();
                _handlers.Add(commandType, untypedValue);
            }
            return (IList<ICommandHandler<TCommand>>) untypedValue;
        }
    }

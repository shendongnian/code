    class CommandStrategies
    {
        private List<ICommandHandler> _commandHandlers;
        public CommandStrategies()
        {
            _commandHandlers = typeof(CommandStrategies)
                .Assembly
                .GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && typeof(ICommandHandler).IsAssignableFrom(x))
                .Select(Activator.CreateInstance)
                .Cast<ICommandHandler>()
                .ToList();
        }
        public bool SupportsCommand(string command)
        {
            return _commandHandlers.Any(x => x.SupportsCommand(command));
        }
        public void ExecuteCommand(string command)
        {
            var handler = _commandHandlers.FirstOrDefault(x => x.SupportsCommand(command));
            if (handler != null)
            {
                handler.ExecuteCommand(command);
            }
        }
        public IEnumerable<string> GetSupportedCommands()
        {
            return _commandHandlers
                .SelectMany(x => x.GetSupportedCommands())
                .Distinct();
        }
    }

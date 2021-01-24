    class ParseFileCommandHandler : ICommandHandler
    {
        public void ExecuteCommand(string command)
        {
            // ...
        }
        public IEnumerable<string> GetSupportedCommands()
        {
            yield return "parse";
        }
        public bool SupportsCommand(string command)
        {
            return command == "parse";
        }
    }
    class PrintFileCommandHandler : ICommandHandler
    {
        public void ExecuteCommand(string command)
        {
            // ...
        }
        public IEnumerable<string> GetSupportedCommands()
        {
            yield return "print";
        }
        public bool SupportsCommand(string command)
        {
            return command == "print";
        }
    }

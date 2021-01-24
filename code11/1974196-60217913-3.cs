    public class BotClass
    {
        private readonly IEnumerable<IBotCommand> _commands;
        public BotClass(IEnumerable<IBotCommand> commands)
        {
            _commands = commands;
        }
        public void PerformCommand(string userInput)
        {
             //go find the right command for your input
             var botCommand = _commands.Where(c => c.CanProcess(userInput).OrderBy(c => c.Priority).First();
             botCommand.Do();
        }
    }

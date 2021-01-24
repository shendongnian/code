    Dictionary<string, List<IExecutionCommand>> listOfUserCommands = new Dictionary<string, List<IExecutionCommand>>();
    
    public interface IExecutionCommand
    {
        Action Action { set; get; }
        List<string> Aliases { set; get; }
    }
    
    public class commandTest : IExecutionCommand
    {
        public Action Action { set; get; }
        public List<string> Aliases { set; get; }
        public commandTest()
        {
            Action = () => { Console.WriteLine("command1 is executed"); };
            Aliases = new List<string>() { "test", "check", "tests" };
        }
    }
    public class commandEx2 : IExecutionCommand
    {
        public Action Action { set; get; }
        public List<string> Aliases { set; get; }
        public commandEx2()
        {
            Action = () => { Console.WriteLine("command2 is executed"); };
            Aliases = new List<string>() { "cmd2" };
        }
    }
    
    
    private IExecutionCommand FindingCommandFromUser(string commandName, List<IExecutionCommand> commandList)
    {
        foreach (IExecutionCommand command in commandList)
            if (command.Aliases.Contains(commandName))
                return command;
        return null;
    }
    
    public static void Main()
    {
        listOfUserCommands.Add("user1",
                                new List<IExecutionCommand>()
                                {
                                        new commandTest(),
                                        new commandEx2()
                                });
    
        string userName = "user1";
        string commandName = "check";
    
        IExecutionCommand curCommand = null;
    
        if (listOfUserCommands.ContainsKey(userName) && ((curCommand = FindingCommandFromUser(commandName, listOfUserCommands[userName])) != null))
            curCommand.Action();
    }

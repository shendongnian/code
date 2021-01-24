    public class ExecutionCommand
            {
                public Action Action { set; get; }
                public List<string> Aliases { set; get; }
                public ExecutionCommand(Action action, List<string> aliases)
                {
                    Action = action;
                    Aliases = aliases;
                }
            }
 
    var commandList = new Dictionary<string, ExecutionCommand>();
                commandList.Add("command1", new ExecutionCommand(() => { Console.WriteLine("command1 is executed");}, new List<string>() {"cmd1" } ));
                commandList.Add("command2", new ExecutionCommand(() => { Console.WriteLine("command2 is executed"); }, new List<string>() { "cmd2" }));
                commandList.Add("command3", new ExecutionCommand(() => { Console.WriteLine("command3 is executed"); }, new List<string>() { "cmd3" }));
                var listOfUserCommands = new Dictionary<string, List<string>>();
                listOfUserCommands.Add("user1", new List<string>() { "cmd2" });
                listOfUserCommands.Add("user2", new List<string>() { "command1", "command3" });
    
                var userName = "user1";
                var commandName = "cmd2";
    
                if (listOfUserCommands.ContainsKey(userName) && listOfUserCommands[userName].Contains(commandName))
                {
                    ExecutionCommand command = commandList.FirstOrDefault(x => x.Key == commandName || x.Value.Aliases.Contains(commandName)).Value;
                    command?.Action();
                }

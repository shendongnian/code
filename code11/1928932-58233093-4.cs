    public interface IExecutionCommand
        {
            Action Action { set; get;}
            List<string> Aliases { set; get; }
    
        }
        public class ExecutionCommand1: IExecutionCommand
        {
            public Action Action { set; get; }
            public List<string> Aliases { set; get; }
            public ExecutionCommand1()
            {
                Action = () => { Console.WriteLine("command1 is executed"); };
                Aliases = new List<string>() { "cmd1" };
            }
        }
        public class ExecutionCommand2: IExecutionCommand
        {
            public Action Action { set; get; }
            public List<string> Aliases { set; get; }
            public ExecutionCommand2()
            {
                Action = () => { Console.WriteLine("command2 is executed"); };
                Aliases = new List<string>() { "cmd2" };
            }
        }
        public class ExecutionCommand3: IExecutionCommand
        {
            public Action Action { set; get; }
            public List<string> Aliases { set; get; }
            public ExecutionCommand3()
            {
                Action = () => { Console.WriteLine("command3 is executed"); };
                Aliases = new List<string>() { "cmd3" };
            }
        }
        public static void Main()
        {
            //_startScanning();
            var commandList = new List<IExecutionCommand>();
            commandList.Add(new ExecutionCommand1());
            commandList.Add(new ExecutionCommand2());
            commandList.Add(new ExecutionCommand3());
            var listOfUserCommands = new Dictionary<string, List<string>>();
            listOfUserCommands.Add("user1", new List<string>() { "cmd2" });
            listOfUserCommands.Add("user2", new List<string>() { "command1", "command3" });
    
            var userName = "user1";
            var commandName = "cmd2";
    
            if (listOfUserCommands.ContainsKey(userName) && listOfUserCommands[userName].Contains(commandName))
            {
                IExecutionCommand command = commandList.FirstOrDefault(x => x.Aliases.Contains(commandName));
                command?.Action();
            }
        }

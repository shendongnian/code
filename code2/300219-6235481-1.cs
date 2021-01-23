    interface ICommand
    {
        string Name { get; }
        void Invoke();
    }
    //Example commands
    class Edit : ICommand
    {
        string Name { get { return "edit"; } }
        void Invoke()
        {
            //Do whatever you need to do for the edit command
        }
    }
    
    class Delete : ICommand
    {
        string Name { get { return "delete"; } }
        void Invoke()
        {
            //Do whatever you need to do for the delete command
        }
    }
    class CommandParser
    {
        private Dictionary<string, ICommand> commands = new ...;
        
        public void AddCommand(ICommand cmd)
        {
            commands.Insert(cmd.Name, cmd);
        }
        
        public void Parse(string commandLine)
        {
            string[] args = SplitIntoArguments(commandLine); //Write that method yourself :)
            foreach(string arg in args)
            {
                ICommand cmd = commands.Find(arg);
                if (!cmd)
                {
                    throw new SyntaxError(String.Format("{0} is not a valid command.", arg));
                }
                cmd.Invoke();
            }
        }
    }
    class CommandParserXyz : CommandParser
    {
        CommandParserXyz()
        {
            AddCommand(new Edit);
            AddCommand(new Delete);
        }
    }

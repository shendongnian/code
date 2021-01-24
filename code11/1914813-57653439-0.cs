    class CommandBuilder
    {
        public string Action { get; set; }
        public string ID { get; set; }
        public string NewText { get; set; }
        public string Type { get; set; }
        public CommandBuilder(string action, string id, string newtext, string type)
        {
            Action = action;
            ID = id;
            NewText = newtext;
            Type = type
    
            //If needed : Call a function here
            Build();
        }
    
        //Separate method, you need to decide access modifier and parameters as per your requirement
        public DataFormatter Build()
        {
            Command cmd2 = new Command(Commands.CommandsEnum.Run);
            DataFormatter df2 = new DataFormatter();
            df2._Command = cmd2;
            Subcommand scmd2 = new Subcommand();
            scmd2.Action = Action;
            scmd2.ID = ID;
            scmd2.NewValueString = NewText;
            scmd2.Type = Type;
            df2._Subcommand = scmd2;
            return df2;
        }
    }

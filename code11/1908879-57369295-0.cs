    private Dictionary<string, ICommand> commandsWithAttributes = new Dictionary<string, ICommand>();
    
    var command1 = new Command(); //Whatever
    
    commandsWithAttributes.Add("-t", command1);
    commandsWithAttributes.Add("--thread", command1);
    
    var command2 = new Command(); //Whatever
    
    commandsWithAttributes.Add("-?", command2);
    commandsWithAttributes.Add("--help", command2);

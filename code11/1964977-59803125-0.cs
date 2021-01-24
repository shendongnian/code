    public bool HasCommand(Terminal owner)
    { 
        var gType = typeof(Command<>).MakeGenericType(owner.GetType());
        var bType = typeof(HelloCommand);
        if (owner is Command)
     }
    

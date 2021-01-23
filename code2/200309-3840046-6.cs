    static void Main(string[] args)
    {
        Command = (Commands)Enum.Parse(typeof(Commands), args[0]);
        switch(Command)
        {
            case Commands.CommandOne: 
                //do something 
                break;
            case Commands.CommandTwo: 
                //do something else
                break;
            ...
            default:
                // default stuff
        }
    }

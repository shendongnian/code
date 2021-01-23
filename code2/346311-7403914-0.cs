    void Main(...)
    {
        DisplayAvailableCommands();
        ProcessCommands();
    }
    void ProcessCommands()
    {
        while(true)
        {
            var command = ReadCommandFromConsole();
            switch(command)
            {
                case "help":
                    DisplayHelp();
                    break;
                case "exit":
                    return;
            }
        }
    }

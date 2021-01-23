    static void Main(string[] args)
    {
        EventLog log = new EventLog("logname", "MyMachine", "source");
    
        log.EntryWritten += new EntryWrittenEventHandler(log_EntryWritten);
        log.EnableRaisingEvents = true;
    
        //Wait for a key to be pressed.
        Console.ReadKey();
    }

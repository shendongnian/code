    struct CompilerGenerated
    {
        int counter = 0;
        public Execute() { ++counter; }
    };
    Notify handler = new CompilerGenerated();
    SignalTwice(handler);
    System.Console.WriteLine(counter); // what should this print?

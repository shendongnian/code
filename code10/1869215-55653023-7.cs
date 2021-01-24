    private static void Main(string[] args)
    {
        MoveCustomerCommandHandler.Register();
        KillCustomerCommandHandler.Register();
        CommandHandlerBase.Handle(new MoveCustomerCommand());
        CommandHandlerBase.Handle(new KillCustomerCommand());
        Console.ReadLine();
    }

    var handler = WindsorContainer
        .Resolve<ICommandHandler<RegisterAssetCommand>);
    var command = new RegisterAssetCommand
    {
        CaseNumber = 1000,
        Operator = GetUserFromPage(),
    };
    handler.Handle(command);

    readonly ICommandFactory factory;
    public Constructor(ICommandFactory factory)
    {
        this.factory = factory;
    }
    public void ExecuteSomeCommand()
    {
        factory.Create( someInt, SomeEnum.EnumValue ).Execute();
    }

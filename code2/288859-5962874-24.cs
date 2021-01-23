    public void ExecuteSomeCommand()
    {
        this.CreateCommand(someInt, SomeEnum.EnumValue).Execute();
    }
    // Your seam
    protected virtual ICommand CreateCommand(int someInt, 
        SomeEnum someEnum)
    {
        return new MyCommand(someInt, SomeEnum.EnumValue);
    }

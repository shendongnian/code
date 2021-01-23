    public void Execute<T>( string commandName)
    {        
        var someType = ObjectFactory.GetNamedInstance<ICommand<T>>(commandName);
        someType.Execute();
    }

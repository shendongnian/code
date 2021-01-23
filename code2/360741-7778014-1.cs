    public void Publish(ICommand cmd) {
        var cmdType = cmd.GetType();
        var handler = IoC.Resolve(typeof(IHandles<>).MakeGenericType(cmdType)) as IHandles<ICommand>;
        if (handler != null)
        {
            // BEGIN SLOW
            handler.Handle(command);
            // END SLOW
        }
        //else throw some exception
    }

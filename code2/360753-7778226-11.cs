    // Bus implementation
    class BusImpl : IBus {
    	public void Publish<T>(T cmd) where T : ICommand {
	        var handler = IoC.Resolve<IHandles<T>>();
	        handler.Handle(cmd);
    	}
    }

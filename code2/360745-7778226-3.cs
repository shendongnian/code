    public static void Main(){
       new BusImpl().Publish(new HelloCommand());
    }
    
    // IoC wrapper
    static class IoC {
    	public static object Resolve(Type t) {
    		return new ConcreteHandlerImpl();
    	}
    }
    
    // Handler interface
    interface IHandles<T> where T : ICommand {
    	void Handle(T command);
    }
    
    // Command interface
    interface ICommand {
    }
    
    
    // Handler implementation
    class ConcreteHandlerImpl : IHandles<HelloCommand> {
    	public void Handle(HelloCommand cmd) {
    		Console.WriteLine("Hello Command executed");
    	}
    }
    
    public class HelloCommand:ICommand{}
    
    // Bus interface
    interface IBus {
    	void Publish<T>(T cmd) where T : ICommand;
    }
    
    // Bus implementation
    class BusImpl : IBus {
    	public void Publish<T>(T cmd) where T : ICommand {
    		var cmdType = cmd.GetType();
    		var handler = (IHandles<T>)IoC.Resolve(typeof(IHandles<>).MakeGenericType(cmdType));
    		handler.Handle(cmd);
    	}
    }

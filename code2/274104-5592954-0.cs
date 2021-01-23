    public interface IEvent
    {
    	
    }
    
    public interface IHandler<T>
    {
    
    }
    
    public class Test //: ITest
    {
    	public void Register<TEvent>(IHandler<TEvent> handler) where TEvent : IEvent
    	{
    		
    	}
    }
    
    public class ChangedEvent : IEvent
    {
    	
    
    }
    public class Example
    {
        public static void Main()
        {
            Test t = new Test();
    		Type[] types = new Type[10];
    		foreach (Type type in types)
    		{
    			object instance = Activator.CreateInstance(type);
    			t.Register((IHandler<IEvent>)instance);
    		}
        }
    }

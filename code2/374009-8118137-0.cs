    public class Foo
    {
    	private TypeWrapper<IInterface1,IInterface2> _object;
    	public void setObject<T>(T obj)
    		where T : IInterface1, IInterface2
    	{
    		_object = new TypeWrapper<IInterface1, IInterface2>();
    		_object.SetObject(obj);
    		
    		var val = _object.Get(h => h.c);
    		Console.WriteLine(val);
    		_object.Do(h => h.c = 25);
    		val = _object.Get(h => h.c);
    		Console.WriteLine(val);
    		_object.Do(h => h.someF());
    	}
    }
    
    public class TypeWrapper<TType, TTypeTwo>
    {
    	private Object m_Obj;
    	public void SetObject<T>(T obj) where T : TType, TTypeTwo
    	{
    		m_Obj = obj;
    	}
    
    	public T Get<T>(Func<TType, T> action)
    	{
    		return (T)action((TType)m_Obj);
    	}
    	public T Get<T>(Func<TTypeTwo, T> action)
    	{
    		return (T)action((TTypeTwo)m_Obj);
    	}
    	
    	public void Do(Action<TTypeTwo> action)
    	{
    		action((TTypeTwo)m_Obj);
    	}
    	
    	public void Do(Action<TType> action)
    	{
    		action((TType)m_Obj);
    	}
    }
    
    public class myClass : IInterface1, IInterface2 {
    	public int t {get;set;}
    	public int c {get;set;}
    	public void someF() { Console.WriteLine("Fired"); }
    	}
    public interface IInterface1 {
    	int t { get;set;} 
    	void someF();
    }
    public interface IInterface2 { 
    	int c { get;set; }
    }

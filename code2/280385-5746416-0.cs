    public interface IClass
    {
    	void MethodToDynamicInvoke();
    }
    
    public abstract class ClassBase<T>
    	: IClass
    {
    	private Dictionary<Type, List<IClass>> instances = new Dictionary<Type, List<IClass>>();
    
    	public ClassBase()
    	{
    		List<IClass> list;
    		if (!instances.TryGetValue(typeof(T), out list))
    		{
    			list = new List<IClass>();
    			instances.Add(typeof(T), list);
    		}
    
    		list.Add(this);
    	}
    
    	public abstract void MethodToDynamicInvoke();
    
    	public void InvokeMetodOnClassesWithSameEnum()
    	{
    		List<IClass> list;
    		if (instances.TryGetValue(EnumType, out list))
    		{
    			foreach (var instance in list)
    			{
    				instance.MethodToDynamicInvoke();
    			}
    		}
    	}
    }
    
    public class ConcreteClass
    	: ClassBase<ConcreteClass.Concrete>
    {
    	public ConcreteClass()
    		: base()
    	{
    	}
    
    	public override void MethodToDynamicInvoke()
    	{
    		throw new NotImplementedException();
    	}
    
    	public enum Concrete : ulong
    	{
    	}
    }
    
    public class OtherClass : ClassBase<OtherClass.Other>
    {
    	public OtherClass()
    		: base()
    	{
    	}
    
    	public override void MethodToDynamicInvoke()
    	{
    		throw new NotImplementedException();
    	}
    
    	public enum Other : ulong
    	{
    
    	}
    }

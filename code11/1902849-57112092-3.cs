    public interface IBaseType { }
    public class ChildProp1 : IBaseType { }
    public class ChildProp2 : IBaseType { }
    
    public abstract class BaseContainer
    {
    	protected BaseContainer(IBaseType type)
    	{
    		Prop = type;
    	}
    
    	public IBaseType Prop { get; private set; }
    }
    
    public class ChildContainer1 : BaseContainer
    {
    	public ChildContainer1()
    	 : base(new ChildProp1())
    	{
    		
    	}
    }
    
    public class ChildContainer2 : BaseContainer
    {
    	public ChildContainer2()
    	 : base(new ChildProp2())
    	{
    
    	}
    }

    public class BasePropType { }
    public class ChildProp1 : BasePropType { }
    public class ChildProp2 : BasePropType { }
    
    public abstract class BaseContainer<T> where T : BasePropType
    {
    	public T Prop;
    }
    
    public class ChildContainer1 : BaseContainer<ChildProp1> { }
    public class ChildContainer2 : BaseContainer<ChildProp2> { }

    public interface INode
    {
    	INode SetName(string aName);
    	INode SetId(string aId);
    }
    
    public class Parent : INode
    {
    	public virtual INode SetId(string id)
    	{
    		...
    		return this
    	}
       
    	public virtual INode SetName(string aId)
    	{
    		return this;
    	}
    }
    
    public class Child : Parent
    {
       public override INode SetName(string id)
       {
          ...
          return this;
       }
    }

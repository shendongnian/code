    public abstract class Field
    {
    }
    
    public abstract class GenericField<T> : Field
    {
    	public void Set(DynamicObject obj, T value)
    	{
    		obj[this.GetType()] = value;
    	}
    }
    
    public class UsernameField : GenericField<string>
    {
    	#region Singleton Pattern
    
    	public static readonly UsernameField Instance = new UsernameField();
    
    	private UsernameField() { }
    
    	#endregion
    
    }

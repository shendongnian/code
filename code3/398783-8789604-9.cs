    public class DynamicObject : Dictionary<Field, object>
    {
    	public void Set<T>(GenericField<T> field, T value)
    	{
    		this[field] = value;
    	}
    }

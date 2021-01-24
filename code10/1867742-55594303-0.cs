    public class ConditionalRule<T, TValue> : DelegateRule<T>
    {
    	public TValue Value { get; private set; }
    
    	public ConditionalRule(string propertyName, object error, Func<T, bool> rule, TValue value)
    		: base(propertyName, error, rule)
    	{
    		Value = value;
    	}
    	
    	public override bool Apply(T obj)
    	{
    		// do your business driven condition check before calling
    		return base.Apply(obj);
    	}
    }

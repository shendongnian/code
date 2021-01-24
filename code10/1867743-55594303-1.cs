    public sealed class RuleCollection<T> : Collection<Rule<T>>
    {
    	#region Public Methods
    
    	/// <summary>
    	/// Adds a new <see cref="Rule{T}"/> to this instance.
    	/// </summary>
    	/// <param name="propertyName">The name of the property the rules applies to.</param>
    	/// <param name="error">The error if the object does not satisfy the rule.</param>
    	/// <param name="rule">The rule to execute.</param>
    	public void Add(string propertyName, object error, Func<T, bool> rule)
    	{
    		this.Add(new DelegateRule<T>(propertyName, error, rule));
    	}
    	
    	public void AddConditional<TValue>(string propertyName, object error, Func<T, bool> rule, TValue value)
    	{
    		this.Add(new ConditionalRule<T, TValue>(propertyName, error, rule, value)
    	}
    
        //....
    	#endregion
    }

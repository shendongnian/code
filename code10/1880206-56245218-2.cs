    public class CustomQueryProvider : DefaultQueryProvider, IQueryProviderWithOptions
    {
    	// Required constructors
    	public CustomQueryProvider(ISessionImplementor session) : base(session) { }
    	public CustomQueryProvider(ISessionImplementor session, object collection) : base(session, collection) { }
    	// The code we need
    	protected override NhLinqExpression PrepareQuery(Expression expression, out IQuery query)
    		=> base.PrepareQuery(expression.ApplySpecifications(), out query);
    	// Hacks for correctly supporting IQueryProviderWithOptions
    	IQueryProvider IQueryProviderWithOptions.WithOptions(Action<NhQueryableOptions> setOptions)
    	{
    		if (setOptions == null)
    			throw new ArgumentNullException(nameof(setOptions));
    		var options = (NhQueryableOptions)_options.GetValue(this);
    		var newOptions = options != null ? (NhQueryableOptions)CloneOptions.Invoke(options, null) : new NhQueryableOptions();
    		setOptions(newOptions);
    		var clone = (CustomQueryProvider)this.MemberwiseClone();
    		_options.SetValue(clone, newOptions);
    		return clone;
    	}
    	static readonly FieldInfo _options = typeof(DefaultQueryProvider).GetField("_options", BindingFlags.NonPublic | BindingFlags.Instance);
    	static readonly MethodInfo CloneOptions = typeof(NhQueryableOptions).GetMethod("Clone", BindingFlags.NonPublic | BindingFlags.Instance);
    }

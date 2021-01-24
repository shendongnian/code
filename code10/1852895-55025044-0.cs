    public class StructuralEqualityComparer : IEqualityComparer
    {
    	private readonly Func<PropertyInfo, bool> _excludePredicate;
    	private readonly StructuralEqualityComparerOptions _options;
    
    	public StructuralEqualityComparer(Func<PropertyInfo, bool> excludePredicate = null, StructuralEqualityComparerOptions options = null)
    	{
    		Func<PropertyInfo, bool> defaultExcludePredicate = (propertyInfo) => false;
    		_excludePredicate = excludePredicate ?? defaultExcludePredicate;
    		_options = options;
    	}
    	
    	public new bool Equals(object x, object y)
    	{
    		if (x == null)
    			return y == null;
    		if (y == null)
    			return false;
    
    		var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
    		var xProperties = x.GetType().GetProperties(bindingFlags);
    		var xPropertiesToCompare = xProperties
    			.Except(xProperties.Where(_excludePredicate))
    			.OrderBy(propertyInfo => propertyInfo.Name);
    
    		var yProperties = y.GetType().GetProperties(bindingFlags);
    		var yPropertiesToCompare = yProperties
    			.Except(yProperties.Where(_excludePredicate))
    			.OrderBy(propertyInfo => propertyInfo.Name);
    
    		Func<object, object, bool> equalityPredicate = (value1, value2) => PropertyEquals(x, y, value1 as PropertyInfo, value2 as PropertyInfo);
    		return SequenceEquals(xPropertiesToCompare, yPropertiesToCompare, equalityPredicate);
    	}
    
    	private bool SequenceEquals(IEnumerable first, IEnumerable second, Func<object, object, bool> equalityPredicate)
    	{
    		var firstEnumerator = first.GetEnumerator();
    		var secondEnumerator = second.GetEnumerator();
    		{
    			while (firstEnumerator.MoveNext())
    			{
    				if (!secondEnumerator.MoveNext())
    					return false;
    				if (!equalityPredicate(firstEnumerator.Current, secondEnumerator.Current))
    					return false;
    			}
    
    			if (secondEnumerator.MoveNext())
    				return false;
    		}
    
    		return true;
    	}
    
    	public int GetHashCode(object obj) => obj.GetHashCode();
    
    	private bool PropertyEquals(object x, object y, PropertyInfo xPropertyInfo, PropertyInfo yPropertyInfo)
    	{
    		if (xPropertyInfo == null)
    			return yPropertyInfo == null;
    		if (yPropertyInfo == null)
    			return false;
    		if (_options.NameCompare)
    		{
    			if (xPropertyInfo.Name != yPropertyInfo.Name)
    				return false;
    		}
    		if (_options.TwoWayAssignableCompare)
    		{
    			if (!xPropertyInfo.PropertyType.IsAssignableFrom(yPropertyInfo.PropertyType) || !yPropertyInfo.PropertyType.IsAssignableFrom(xPropertyInfo.PropertyType))
    				return false;
    		}
    		else if (_options.OneWayAssignableCompare)
    		{
    			if (!xPropertyInfo.PropertyType.IsAssignableFrom(yPropertyInfo.PropertyType))
    				return false;
    		}
    		if (_options.ValueCompare)
    		{    
    			var xValue = xPropertyInfo.GetValue(x);
    			var yValue = yPropertyInfo.GetValue(y);
    
    			if (xValue is IEnumerable || yValue is IEnumerable)
    			{
    				return SequenceEquals(xValue as IEnumerable, yValue as IEnumerable, _options.EqualityComparer.Equals);
    			}
    
    			if (_options.EqualityComparer.Equals(xValue, yValue) || _options.EqualityComparer.Equals(yValue, xValue))
    				return true;
    
    			if (_options.RecursiveCompare && (xValue != x || yValue != y))
    			{
    				return Equals(xValue, yValue);
    			}
    		}
    		return true;
    	}
    }
    
    public class StructuralEqualityComparerOptions
    {
    	/// <summary>
    	/// Check that the names of the properties match
    	/// </summary>
    	public bool NameCompare { get; set; } = true;
    	/// <summary>
    	/// Check that the Type of TY can be assigned to TX.
    	/// </summary>
    	public bool OneWayAssignableCompare { get; set; } = true;
    	/// <summary>
    	/// Check that the Type of TY can be assigned to TX and vise versa, skips OneWayAssignableCompare.
    	/// </summary>
    	public bool TwoWayAssignableCompare { get; set; } = false;
    	/// <summary>
    	/// Check that the values of the properties match, using EqualityComparer
    	/// </summary>
    	public bool ValueCompare { get; set; } = true;
    	/// <summary>
    	/// Recursively walk for nested types
    	/// </summary>
    	public bool RecursiveCompare { get; set; } = true;
    	/// <summary>
    	/// The IEqualityComparer to use for ValueCompare
    	/// </summary>
    	public IEqualityComparer EqualityComparer { get; set; } = EqualityComparer<object>.Default;
    }

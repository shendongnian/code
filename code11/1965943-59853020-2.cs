    public static Expression<Func<Movement, bool>> CompareToStr(string searchString) 
    {
    	Expression res = null;
    	var param = Expression.Parameter(typeof(Movement), "x");
    	foreach (var component in typeof(Movement).GetProperties())
    	{
    		// building the expression to get a property
    		var arg = Expression.Property(param, component.Name);
    		// now we have `x.Property1` expression
    		
    		var toStrCall = Expression.Call(
    				// to what expression we applying the .ToString method
    				arg,
    				// link to 'ToString', 
    				// needed to be altered, if it would be used in non-sql runtime as if there are nullable types with `null` values, this would cause NRE at runtime
    				typeof(Movement).GetMethod(nameof(Movement.ToString), new Type[] { }));
    		// now we have `x.Property1.ToString()` (watch out NRE)
    		
    		var toLowerCall = Expression.Call(
    			toStrCall, 
    			typeof(string).GetMethod(nameof(string.ToLower), new Type[] { }));
    			
    		// now we have `x.Property1.ToString().ToLower()`
    		var containsCall = Expression.Call(
    				toLowerCall,
    				typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) }),
    				Expression.Constant(searchString.ToLower())); // since arguments of expression tree should be the expressions
    		// here we passed the constant string expression, so now we have
    		// x.Property1.ToString().ToLower().Contains( value of testString.ToLower())
    		
    		if (res == null)
    		{
    			res = containsCall;
    		}
    		else
    		{
    			res = Expression.Or(res, containsCall);
    		}
    		
    		// after several iterations it has
    		// x.Property1...Contains(testString) || x.Property2...Contains(testString) and so on
    	}
    
    	return Expression.Lambda<Func<Movement, bool>>(res, param);
    	// and result x => x.Property1... || x.Property2 ...
    }

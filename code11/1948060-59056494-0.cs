    public class OrmJoin
    {
    	// ...
    	
    	public Expression AsTyped()
    	{
    		var parameters = new[] { Type1, Type2 }
    			.Select(Expression.Parameter)
    			.ToArray();
    		var castedParameters = parameters
    			.Select(x => Expression.Convert(x, typeof(object)))
    			.ToArray();
    		var invocation = Expression.Invoke(Predicate, castedParameters);
    		
    		return Expression.Lambda(invocation, parameters);
    	}
    	public Expression<Func<T1, T2, bool>> AsTyped<T1, T2>() => (Expression<Func<T1, T2, bool>>)AsTyped();
    }
---
    void Main()
    {
    	var test = new OrmJoin { Type1 = typeof(string), Type2 = typeof(int), Predicate = (a,b) => Test(a,b) };
     	var compiled = test.AsTyped<string, int>().Compile();
    	
    	Console.WriteLine(compiled.Invoke("asd", 312));
    }
    bool Test(object a, object b)
    {
    	Console.WriteLine(a);
    	Console.WriteLine(b);
    	return true;
    }

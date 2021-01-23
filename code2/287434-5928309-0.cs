    public static class MyUnityExtensions
    {
    	public static IEnumerable<T> ResolveStartsWith<T>(this IUnityContainer c, string match)
    	{
    		var matches = c.Registrations.Where(r => r.Name.StartsWith(match));
    
    		foreach (var registration in matches)
    		{
    			yield return c.Resolve<T>(registration.Name);
    		}
    	}
    }

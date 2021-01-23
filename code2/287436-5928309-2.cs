    public static class MyUnityExtensions
    {
    	public static IEnumerable<T> Resolve<T>(this IUnityContainer c, Func<string, bool> match)
    	{
    		var matches = c.Registrations.Where(r => match(r.Name));
    
    		foreach (var registration in matches)
    		{
    			yield return c.Resolve<T>(registration.Name);
    		}
    	}
    
    }

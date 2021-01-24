cs
public IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector)
{
	lock (_lock)
	{
		return System.Linq.Enumerable.Select(this, selector);
	}
}
But keep in mind, that [`Select`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select?view=netframework-4.8#System_Linq_Enumerable_Select__2_System_Collections_Generic_IEnumerable___0__System_Func___0_System_Int32___1__) method from `System.Linq` is extension method actually. `Linq` also uses deferred execution, you can evaluate result into list using `ToList()` method before return it, like that
cs
using System.Linq;
...
public IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector)
{
	lock (_lock)
	{
		return Enumerable.Select(this, selector).ToList();
	}
}

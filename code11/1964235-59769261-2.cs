cs
public interface ICountable
{
	int Count();
}
You should use this interface to mark all types, which properties are participating in `Count()` calculation.
You can see the generic abstract class to implement this interface below. Generic `T` parameter is type whose properties need to be calculated. You implement a calculation logic only once and inherit this class where needed. You also go through all of properties, implementing `ICountable`, to calculate them as well (some kind of recursion)
cs
public abstract class Countable<T> : ICountable
{
	public int Count()
	{
		Type t = typeof(T);
		var properties = t.GetProperties();
		var countable = properties.Select(p => p.PropertyType).Where(p => typeof(ICountable).IsAssignableFrom(p));
		var sum = countable.Sum(c => c.GetProperties().Length);
		return properties.Length + sum;
	}
}
and inherit it in your classes
cs
public class DataClass : Countable<DataClass>
{
...
}
public class PartClass : Countable<PartClass>
{
...
}
public class MemberClass : Countable<MemberClass>
{
...
}
public class SideClass : Countable<SideClass>
{
...
}
And this is for the test
cs
var dataClass = new DataClass();
var count = dataClass.Count();
It returns `8` as expected

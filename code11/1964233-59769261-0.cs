cs
public interface ICountable
{
	int Count();
}
And generic abstract class to implement it
cs
public abstract class Countable<T> : ICountable
{
	public int Count()
	{
		Type t = typeof(T);
		var properties = t.GetProperties();
		var countable = properties.Select(p=>p.PropertyType).Where(p => typeof(ICountable).IsAssignableFrom(p));
		var sum = countable.Sum(c => c.GetProperties().Length);
		return properties.Length + sum;
	}
}
and inherit it in your classes
cs
public class DataClass : Countable<DataClass>
{
//list of properties
}
public class PartClass : Countable<PartClass>
{
//list of properties
}
public class MemberClass : Countable<MemberClass>
{
//list of properties
}
public class SideClass : Countable<MemberClass>
{
//list of properties
}
And this is for the test
cs
var dataClass = new DataClass();
var count = dataClass.Count();
It retursns `8` as expected

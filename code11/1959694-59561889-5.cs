cs
public abstract class PersistenceEntity<T> where T : PersistenceEntity<T>
{
	public abstract T Update(T existing);
}
This means self-referencing generic constraint, because every class inheriting `PersistenceEntity` should update the existing instance of itself type
The implementation for `MyClass` would be as following:
cs
public class MyClass : PersistenceEntity<MyClass>
{
	public override MyClass Update(MyClass existing)
	{
		existing.SomeProperty = SomeProperty;
		existing.SomeProperty2 = SomeProperty2;
		return existing;
	}
}
Another option is to create an invariant interface, which incapsulates the `Update` method (if you aren't allowed to make`PersistenceEntity` class generic)
cs
public interface IUpdate<T> where T : PersistenceEntity
{
	T Update(T existing);
}
And then implement it
cs
public class MyClass : PersistenceEntity, IUpdate<MyClass>
{
	public MyClass Update(MyClass existing)
	{
		existing.SomeProperty = SomeProperty;
		existing.SomeProperty2 = SomeProperty2;
		return existing;
	}
}

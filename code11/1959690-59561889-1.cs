cs
public abstract class PersistenceEntity<T> where T : PersistenceEntity<T>
{
	public abstract T Update(T existing);
}
This means self-referencing generic constraint, because every class inheriting `PersistenceEntity` should update the existing instance of the same type. The `MyClass` implementation will be like this
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

cs
public abstract class PersistenceEntity<T> where T : PersistenceEntity<T>
{
	public abstract T Update(T existing);
}
This means self-referencing generic constraint, because every class inheriting `PersistenceEntity` should update the existing instance of the same type
The implementation for `MyClass` would be as following:
    public class MyClass : PersistenceEntity<MyClass>
    {
    	public override MyClass Update<MyClass>(MyClass existing)
    	{
    		existing.SomeProperty = SomeProperty;
    		existing.SomeProperty2 = SomeProperty2;
    		return existing;
    	}
    }

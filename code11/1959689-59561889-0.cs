cs
public abstract class PersistenceEntity<T> where T : PersistenceEntity<T>
{
	public abstract T Update(T existing);
}
This means self-referencing generic constraint, because every class inheriting `PersistenceEntity` should update the existing instance of the same type

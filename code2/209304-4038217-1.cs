	public interface IListReader<out T> : IEnumerable<T>
	{
		T this[int index] { get; }
		int Count { get; }
	}

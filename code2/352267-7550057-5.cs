	public class ComputedValue<T> : IObservable<T>, IDisposable
	{
		public ComputedValue(IObservable<T> source) { ... }
		public T Value { get; }
		public IDisposable Subscribe(IObserver<T> observer);
		public void Dispose();
	}

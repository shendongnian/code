	public class ObservableValue<T> : IObservable<T>, IDisposable
	{
		public ObservableValue(T initial) { ... }
		public T Value { get; set; }
		public IDisposable Subscribe(IObserver<T> observer);
		public void Dispose();
	}

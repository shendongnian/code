	public class ThreadLocalDisposables<T> : IDisposable
		where T : IDisposable
	{
		private ThreadLocal<T> _threadLocal = null;
		private ConcurrentBag<T> _values = new ConcurrentBag<T>();
		
		public ThreadLocalDisposables(Func<T> valueFactory)
		{
			_threadLocal = new ThreadLocal<T>(() =>
			{
				var value = valueFactory();
				_values.Add(value);
				return value;
			});
		}
	
		public void Dispose()
		{
			_threadLocal.Dispose();
			Array.ForEach(_values.ToArray(), t => t.Dispose());
		}
	
		public override string ToString()
		{
			return _threadLocal.ToString();
		}
	
		public bool IsValueCreated
		{
			get { return _threadLocal.IsValueCreated; }
		}
	
		public T Value
		{
			get { return _threadLocal.Value; }
		}
	}

	public sealed class CompositeDisposable : IEnumerable<IDisposable>, IDisposable
	{
		private readonly List<IDisposable> _disposables;
		private bool _disposed;
		public CompositeDisposable()
		{
			_disposables = new List<IDisposable>();
		}
		public CompositeDisposable(IEnumerable<IDisposable> disposables)
		{
			if (disposables == null)
				{ throw new ArgumentNullException("disposables"); }
			_disposables = new List<IDisposable>(disposables);
		}
		public CompositeDisposable(params IDisposable[] disposables)
		{
			if (disposables == null)
				{ throw new ArgumentNullException("disposables"); }
			_disposables = new List<IDisposable>(disposables);
		}
		public void Add(IDisposable disposable)
		{
			if (disposable == null)
				{ throw new ArgumentNullException("disposable"); }
			lock (_disposables)
			{
				if (_disposed)
				{
					disposable.Dispose();
				}
				else
				{
					_disposables.Add(disposable);
				}
			}
		}
		
		public IDisposable Add(Action action)
		{
			if (action == null) { throw new ArgumentNullException("action"); }
			var disposable = new AnonymousDisposable(action);
			this.Add(disposable);
			return disposable;
		}
		public IDisposable Add<TDelegate>(
				Action<TDelegate> add,
				Action<TDelegate> remove,
				TDelegate handler)
		{
			if (add == null) { throw new ArgumentNullException("add"); }
			if (remove == null) { throw new ArgumentNullException("remove"); }
			if (handler == null) { throw new ArgumentNullException("handler"); }
			add(handler);
			return this.Add(() => remove(handler));
		}
		public void Clear()
		{
			lock (_disposables)
			{
				var disposables = _disposables.ToArray();
				_disposables.Clear();
				Array.ForEach(disposables, d => d.Dispose());
			}
		}
		public void Dispose()
		{
			lock (_disposables)
			{
				if (!_disposed)
				{
					this.Clear();
				}
				_disposed = true;
			}
		}
		public IEnumerator<IDisposable> GetEnumerator()
		{
			lock (_disposables)
			{
				return _disposables.ToArray().AsEnumerable().GetEnumerator();
			}
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		public bool IsDisposed
		{
			get
			{
				return _disposed;
			}
		}
	}

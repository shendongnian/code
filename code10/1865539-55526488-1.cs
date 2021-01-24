	public class MyReactiveList<T> : IObservable<IReadOnlyList<T>>, IList<IObservable<T>>
	{
		private List<IObservable<T>> _list = new List<IObservable<T>>();
		
		private Subject<Unit> _update = new Subject<Unit>();
	
		public IDisposable Subscribe(IObserver<IReadOnlyList<T>> observer) =>
			_update
				.Select(_ => _list.CombineLatest().Select(x => new ReadOnlyList<T>(x)))
				.Switch()
				.Subscribe(observer);
				
		public IObservable<T> this[int index]
		{
			get => _list[index];
			set
			{
				_list[index] = value;
				_update.OnNext(Unit.Default);
			}
		}
	
		public int Count => _list.Count;
	
		public bool IsReadOnly => false;
	
		public void Add(IObservable<T> item)
		{
			_list.Add(item);
			_update.OnNext(Unit.Default);
		}
	
		public void Clear()
		{
			_list.Clear();
			_update.OnNext(Unit.Default);
		}
	
		public bool Contains(IObservable<T> item) => _list.Contains(item);
	
		public void CopyTo(IObservable<T>[] array, int arrayIndex)
		{
			_list.CopyTo(array, arrayIndex);
		}
	
		public IEnumerator<IObservable<T>> GetEnumerator() => _list.GetEnumerator();
	
		public int IndexOf(IObservable<T> item) => _list.IndexOf(item);
	
		public void Insert(int index, IObservable<T> item)
		{
			_list.Insert(index, item);
			_update.OnNext(Unit.Default);
		}
	
		public bool Remove(IObservable<T> item)
		{
			var removed = _list.Remove(item);
			_update.OnNext(Unit.Default);
			return removed;
		}
	
		public void RemoveAt(int index)
		{
			_list.RemoveAt(index);
			_update.OnNext(Unit.Default);
		}
	
		IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
	}
	
	public class ReadOnlyList<T> : IReadOnlyList<T>
	{
		public ReadOnlyList(IEnumerable<T> items) { _list.AddRange(items); }
		
		private List<T> _list = new List<T>();
	
		public T this[int index] => _list[index];
	
		public int Count => _list.Count;
	
		public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
	
		IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
	}

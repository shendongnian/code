	public abstract class ConcurrentCollection<T> : ICollection<T>
	{
		private List<T> List { get; set; }
		public ConcurrentCollection()
		{
			this.List = new List<T>();
		}
		public T this[int index]
		{
			get
			{
				return this.List[index];
			}
		}
		protected virtual void AddUnsafe(T item)
		{
			this.List.Add(item);
		}
		protected virtual void RemoveUnsafe(T item)
		{
			this.List.Remove(item);
		}
		protected virtual void ClearUnsafe()
		{
			this.List.Clear();
		}
		public void Add(T item)
		{
			lock (this.List)
			{
				this.AddUnsafe(item);
			}
		}
		public bool Remove(T item)
		{
			lock (this.List)
			{
				this.RemoveUnsafe(item);
				return true;
			}
		}
		public void Clear()
		{
			lock (this.List)
			{
				this.ClearUnsafe();
			}
		}
		public int Count
		{
			get
			{
				lock (this.List)
				{
					return this.List.Count;
				}
			}
		}
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}
		public bool Contains(T item)
		{
			lock (this.List)
			{
				return this.List.Contains(item);
			}
		}
		public void CopyTo(T[] array, int arrayIndex)
		{
			lock (this.List)
			{
				this.List.CopyTo(array, arrayIndex);
			}
		}
		public IEnumerator<T> GetEnumerator()
		{
			return new ConcurrentEnumerator<T>(this.List, this.List);
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException("Abstract concurrent enumerators not implemented.");
		}
	}
	public class ConcurrentEnumerator<T> : IEnumerator<T>
	{
		private int Position = -1;
		private List<T> Duplicate;
		private object Mutex;
		private ICollection<T> NonConcurrentCollection;
		internal ConcurrentEnumerator(ICollection<T> nonConcurrentCollection, object mutex)
		{
			this.NonConcurrentCollection = nonConcurrentCollection;
			this.Mutex = mutex;
			lock (this.Mutex)
			{
				this.Duplicate = new List<T>(this.NonConcurrentCollection);
			}
		}
		public T Current
		{
			get
			{
				return this.Duplicate[this.Position];
			}
		}
		object IEnumerator.Current
		{
			get
			{
				return this.Current;
			}
		}
		public bool MoveNext()
		{
			this.Position++;
			lock (this.Mutex)
			{
				while (this.Position < this.Duplicate.Count && !this.NonConcurrentCollection.Contains(this.Current))
				{
					this.Position++;
				}
			}
			return this.Position < this.Duplicate.Count;
		}
		public void Reset()
		{
			this.Position = -1;
		}
		public void Dispose() { }
	}
	// Standards have List as derived Collection...
	public class ConcurrentList<T> : ConcurrentCollection<T> { }

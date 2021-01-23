	public class LockingList<T> : IList<T>
	{
		public LockingList(IList<T> inner)
		{
			this.Inner = inner;
		}
		private readonly object gate = new object();
		public IList<T> Inner { get; private set; }
		public int IndexOf(T item)
		{
			lock (gate)
			{
				return this.Inner.IndexOf(item);
			}
		}
		public void Insert(int index, T item)
		{
			lock (gate)
			{
				this.Inner.Insert(index, item);
			}
		}
		public void RemoveAt(int index)
		{
			lock (gate)
			{
				this.Inner.RemoveAt(index);
			}
		}
		public T this[int index]
		{
			get
			{
				lock (gate)
				{
					return this.Inner[index];
				}
			}
			set
			{
				lock (gate)
				{
					this.Inner[index] = value;
				}
			}
		}
		public void Add(T item)
		{
			lock (gate)
			{
				this.Inner.Add(item);
			}
		}
		public void Clear()
		{
			lock (gate)
			{
				this.Inner.Clear();
			}
		}
		public bool Contains(T item)
		{
			lock (gate)
			{
				return this.Inner.Contains(item);
			}
		}
		public void CopyTo(T[] array, int arrayIndex)
		{
			lock (gate)
			{
				this.Inner.CopyTo(array, arrayIndex);
			}
		}
		public int Count
		{
			get
			{
				lock (gate)
				{
					return this.Inner.Count;
				}
			}
		}
		public bool IsReadOnly
		{
			get
			{
				lock (gate)
				{
					return this.Inner.IsReadOnly;
				}
			}
		}
		public bool Remove(T item)
		{
			lock (gate)
			{
				return this.Inner.Remove(item);
			}
		}
		public IEnumerator<T> GetEnumerator()
		{
			lock (gate)
			{
				return this.Inner.ToArray().AsEnumerable().GetEnumerator();
			}
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			lock (gate)
			{
				return this.Inner.ToArray().GetEnumerator();
			}
		}
	}

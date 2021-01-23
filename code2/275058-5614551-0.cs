	public class MyList<T> : Dictionary<int, T>, IEnumerable<T> where T : KeyedBase
	{
		public void Add(T itm)
		{
			Add(itm.Key, itm);
		}
		
		public virtual IEnumerator<T> GetEnumerator()
		{
			return Values.GetEnumerator();
		}
	}

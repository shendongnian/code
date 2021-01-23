    public sealed class CustomCollection<T> : IList<T>
    {
	    private IList<T> wrappedCollection;
		
	    public CustomCollection(IList<T> wrappedCollection)
		{
			if (wrappedCollection == null)
			{
				throw new ArgumentNullException("wrappedCollection");
			}
		    this.wrappedCollection = wrappedCollection;
		}
		
		// "hide" methods that don't make sense by explicitly implementing them and
		// throwing a NotSupportedException
		void IList<T>.RemoveAt(int index)
		{
		    throw new NotSupportedException();
		}
		
		// Implement methods that do make sense by passing the call to the wrapped collection
		public void Add(T item)
        {
            this.wrappedCollection.Add(item);
        }
	}

    public class MyCollection : Collection<MyItem>
    {
		public MyItem this[int index]
		{
                // make sure we get Collection<T>'s indexer instead.
			get { return ((Collection<MyItem>)this)[index]; }
		}
    }

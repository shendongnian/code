    public class MyCollection<T> : ListCollectionView
	{
		public MyCollection(List<T> list)
			: base(list)
		{
		}
		public override object GetItemAt(int index)
		{
			Debug.WriteLine(index);
			return base.GetItemAt(index);
		}
	}

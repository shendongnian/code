	public sealed class Foo
	{
		private readonly List<object> _items = new List<object>();
		
		public IEnumerable<object> Items
		{
			get
			{
				foreach (var item in this._items)
				{
					yield return item;
				}
				yield break;
			}
		}
	}

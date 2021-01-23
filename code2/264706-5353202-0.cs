    class Program
	{
		private static readonly IList<IListItem> _items = new List<IListItem>();
		public static void AddListItem<T>(T listItem) where T : IListItem
		{
			_items.Add(listItem);
			foreach (var item in _items)
			{
				Console.WriteLine(item.ToString());
			}
			Console.ReadLine();
		}
		static void Main(string[] args)
		{
			Test tester = new Test();
			AddListItem(tester);
		}
	}
	internal interface IListItem
	{
	}
	public class Test : IListItem
	{
	}

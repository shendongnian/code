	public class ArchiveMenuModel
	{
		private List<ArchiveMenuItem> menuItems;
		public List<ArchiveMenuItem> MenuItems { get { return menuItems; } }
		public ArchiveMenuModel(List<DateTime> dates, string streamUrl)
		{
			menuItems = new List<ArchiveMenuItem>();
			dates = dates.OrderByDescending(x => x).ToList();
			var grouped = from d in dates
							group d by new { month = d.Month, year= d.Year } into d     
							select new { dt = d, count = d.Count() };
			foreach(var item in grouped)
			{
				menuItems.Add(new ArchiveMenuItem(streamUrl, item.dt.Key.month, item.dt.Key.year, item.count));
			}
		}
	}

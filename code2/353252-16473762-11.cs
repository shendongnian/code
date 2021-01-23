	public class ListHelper
	{
		public IEnumerable<SelectListItem> GetTimeZoneList()
		{
			var list = from tz in TimeZoneInfo.GetSystemTimeZones()
					   select new SelectListItem { Value = tz.Id, Text = tz.DisplayName };
			return list;
		}
	}

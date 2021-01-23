	public partial class _Default : System.Web.UI.Page
	{
		public class Entry
		{
			public string Month {get;set;}
			public string Name {get;set;}
		}
		List<Entry> entries = new List<Entry>()
		{
			new Entry() { Month = "Jan", Name = "name1"},
			new Entry() { Month = "Jan", Name = "name2"},
			new Entry() { Month = "Feb", Name = "name3"},
			new Entry() { Month = "Aug", Name = "name4"},
			new Entry() { Month = "Dec", Name = "name5"},
			new Entry() { Month = "Dec", Name = "name6"}
		};
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				MonthList.DataSource = entries.GroupBy(x => x.Month).Select(x => x.Key);
				MonthList.DataBind();
			}
		}
		protected void MonthList_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				var itemList = (Repeater)e.Item.FindControl("ItemList");
				var month = (string)e.Item.DataItem;
				itemList.DataSource = entries.Where(x => x.Month == month);
				itemList.DataBind();
			}
		}
	}

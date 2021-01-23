    public partial class MyCustomItem : Sitecore.Data.Items.CustomItem
    {
        public const string TitleFieldName = "Title";
        public MyCustomItem(Item innerItem) : base(innerItem)
		{
		}
		public static implicit operator MyCustomItem(Item innerItem)
		{
			return innerItem != null ? new Report(innerItem) : null;
		}
		public static implicit operator Item(MyCustomItem customItem)
		{
			return customItem != null ? customItem.InnerItem : null;
		}
        public string Title
		{
			get	{ return InnerItem[TitleFieldName]); }
		}
    }

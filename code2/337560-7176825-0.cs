    public class CustomListViewItem : ListViewItem
    {
        public CustomListViewItemType Type { get; set; }
    }
    public enum CustomListViewItemType
    {
        Type1 = 0,
        Type2 = 1
    }
----------
    lstviewcategories.Items.Add(new CustomListViewItem() { Text = "ALL", Group = pricerangegroup, Type = CustomListViewItemType.Type2 });

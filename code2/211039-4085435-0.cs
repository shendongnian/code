    public static class ListViewExtensions
    {
        public static ListView AddItems(this ListView listView,
            IEnumerable<ListViewItem> items)
        {
            listView.Items.AddRange(items.ToArray());
            return listView;
        }
        public static ListViewItem WithSubItems(this ListViewItem item,
            IEnumerable<string> subItems)
        {
            item.SubItems.AddRange(subItems.ToArray());
            return item;
        }
    }

    public static class ListViewExtensions
    {
        public static ListViewItem WithSubItems(this ListViewItem item, IEnumerable<string> subItems)
        {
            item.SubItems.AddRange(subItems.Select(subItem => subItem).ToArray());
            return item;
        }
    }

    static class ListViewItemFactory
    {
        public static ListViewItem Create(string text,string subItem)
        {
           ListViewItem item = new ListViewItem();
           item.Text = text;
           item.SubItems.Add(subItem);
           return item;
        }
    }

    public static class ExtensionMethods
    {
        public static void Sort(this ListControl lb, bool desc = false)
        {
            var list = lb.Items.Cast<ListItem>().ToArray();
            list = desc
                        ? list.OrderByDescending(x => x.Text).ToArray()
                        : list.OrderBy(x => x.Text).ToArray();
            lb.Items.Clear();
            lb.Items.AddRange(list);
        }
        public static void SortByValue(this ListControl lb, bool desc = false)
        {
            var list = lb.Items.Cast<ListItem>().ToArray();
            list = desc
                        ? list.OrderByDescending(x => x.Value).ToArray()
                        : list.OrderBy(x => x.Value).ToArray();
            lb.Items.Clear();
            lb.Items.AddRange(list);
        }
        public static void SortByText(this ListControl lb, bool desc = false)
        {
            lb.Sort(desc);
        }
        public static void SortRandom(this ListControl lb)
        {
            var list = lb.Items.Cast<ListItem>()
                                .OrderBy(x => Guid.NewGuid().ToString())
                                .ToArray();
            lb.Items.Clear();
            lb.Items.AddRange(list);
        }
    }

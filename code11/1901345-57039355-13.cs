    this.MyItems  = new ViewableCollection<IHost>();
    // decide how your items will be sorted (important: first sort groups, then items in groups)
    this.MyItems.View.SortDescriptions.Add(new SortDescription("HostType", ListSortDirection.Ascending)); // sorting of groups
    this.MyItems.View.SortDescriptions.Add(new SortDescription("Hostname", ListSortDirection.Ascending)); // sorting of items
    PropertyGroupDescription groupDescription = new PropertyGroupDescription("HostType");
    this.MyItems.View.GroupDescriptions.Add(groupDescription);
    this.MyItems.View.CurrentChanged += MyItems_CurrentChanged;
    this.MyItems.AddRange(new IHost[] {
               new HistoryItem { Hostname = "ccc" },
               new HistoryItem { Hostname = "aaa" },
               new HistoryItem { Hostname = "xxx" },
               new FavoriteItem { Hostname = "vvv" },
               new FavoriteItem { Hostname = "bbb" },
               new FavoriteItem { Hostname = "ttt" } });

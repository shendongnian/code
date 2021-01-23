    public sealed class ViewModel
    {
        public ObservableCollection<TabItem> Tabs {get;set;}
        public ViewModel()
        {
            Tabs = new ObservableCollection<TabItem>();
            Tabs.Add(new TabItem { Header = "One", Content = "One's content" });
            Tabs.Add(new TabItem { Header = "Two", Content = "Two's content" });
        }
    }
    public sealed class TabItem
    {
        public string Header { get; set; }
        public string Content { get; set; }
    }

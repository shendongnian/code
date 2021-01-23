    class BottomPanelViewModel
    {
        public BottomPanelViewModel()
        {
            Items = new ObservableCollection<PageViewModel>();
            ItemsView = new ListCollectionView(Items);
            ItemsView.CurrentChanged += SelectionChanged;
        }
    
        public ObservableCollection<PageViewModel> Items { get; private set; }
        public ListCollectionView ItemsView { get; private set; }
    
    }    
    
    class RecentPanelViewModel
    {
        public RecentPanelViewModel()
        {
            Items = new ObservableCollection<PageViewModel>();
        }
    
        public ObservableCollection<PageViewModel> Items { get; private set; }
    }
    
    class WindowViewModel
    {
        public WindowViewModel()
        {
            BottomPanel = new BottomPanelViewModel();
            RecentPanel = new RecentPanelViewModel();
    
            BottomPanel.CurrentChanged +=  (s, e) =>
            {
                RecentPanel.Items.Add(BottomPanel.ItemsView.CurrentItem);
            };
        }
    
        public BottomPanelViewModel BottomPanel { get; private set; }
        public RecentPanelViewModel RecentPanel { get; private set; }
    }

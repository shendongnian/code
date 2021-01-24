    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Demo Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private IEnumerable<Item> _playNowItems;
        public IEnumerable<Item> PlayingNowItems
        {
            get { return _playNowItems; }
            set { SetProperty(ref _playNowItems, value); }
        }
        public MainWindowViewModel()
        {
            PlayingNowItems = new List<Item>
            {
                new Item { Name="Item1", Album="Album1", Artist="Artist1", Duration=60 },
                new Item { Name="Item2", Album="Album2", Artist="Artist2", Duration=60 },
                new Item { Name="Item3", Album="Album3", Artist="Artist3", Duration=60 },
                new Item { Name="Item4", Album="Album4", Artist="Artist4", Duration=60 },
            };
        }
        private DelegateCommand _outerClickCommand;
        public DelegateCommand OuterClickCommand =>
            _outerClickCommand ?? (_outerClickCommand = new DelegateCommand(ExecuteOuterClickCommand));
        void ExecuteOuterClickCommand()
        {
            MessageBox.Show("Outer Clicked");
        }
        private DelegateCommand _innerClickCommand;
        public DelegateCommand InnerClickCommand =>
            _innerClickCommand ?? (_innerClickCommand = new DelegateCommand(ExecuteInnerClickCommand));
        void ExecuteInnerClickCommand()
        {
            MessageBox.Show("Inner 1 Clicked");
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public long Duration { get; set; }
        private DelegateCommand _innerClickCommand;
        public DelegateCommand InnerClickCommand =>
            _innerClickCommand ?? (_innerClickCommand = new DelegateCommand(ExecuteInnerClickCommand));
        void ExecuteInnerClickCommand()
        {
            MessageBox.Show("Inner 2 Clicked");
        }
    }

        public class Type3VM : INotifyPropertyChanged
    {
        private List<MenuData> menuData = new List<MenuData>(new[] 
        {
            new MenuData("Zero", 0),
            new MenuData("One", 1),
            new MenuData("Two", 2),
            new MenuData("Three", 3),
        });
        public IEnumerable<MenuData> MenuData { get { return menuData.ToList(); } }
     
        private int selected;
        public int Selected
        {
            get { return selected; }
            set { selected = value; OnPropertyChanged(); }
        }
        private ICommand contextMenuClickedCommand;
        public ICommand ContextMenuClickedCommand { get { return contextMenuClickedCommand; } }
        private void ContextMenuClickedAction(object clicked)
        {
            var data = clicked as MenuData;
            Selected = data.Item2;
            OnPropertyChanged("MenuData");
        }
        public Type3VM()
        {
            contextMenuClickedCommand = new RelayCommand(ContextMenuClickedAction);
        }
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class MenuData : Tuple<String, int>
    {
        public MenuData(String DisplayValue, int value) : base(DisplayValue, value) { }
    }

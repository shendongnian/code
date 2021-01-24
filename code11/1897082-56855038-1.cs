        public MainPageModelView model { get; set; }
        public MainPage()
        {
            InitializeComponent();
           
            model = new MainPageModelView();
            BindingContext = model;
        }
      
    }
MainPageModelView.cs
    public class MainPageModelView: INotifyPropertyChanged
    {
        public ObservableCollection<HomeMenuItem> menuItems { set; get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public MainPageModelView()
        {
            menuItems = new ObservableCollection<HomeMenuItem>();
            menuItems.Add(new HomeMenuItem() { Name = "Mr. Mono1", Id = 1 });
            menuItems.Add(new HomeMenuItem() { Name = "Mr. Mono2", Id = 2 });
            menuItems.Add(new HomeMenuItem() { Name = "Mr. Mono3", Id = 3 });
            menuItems.Add(new HomeMenuItem() { Name = "Mr. Mono4", Id = 4 });
        }
       
        private HomeMenuItem selectedItem { get; set; }
        public HomeMenuItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                this.OnPropertyChanged();
            }
        }
      
        Command _updateCommand;
        public Command UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new Command(ExecuteSaveCommand));
            }
        }
        void ExecuteSaveCommand()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                   SelectedItem = menuItems[0];
            });
            //SelectedItem = menuItems.Where(s => s.Id.Equals(menuItem.Id)).FirstOrDefault();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName));
        }
    }

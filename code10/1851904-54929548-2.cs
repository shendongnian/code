    public class MenuItemVM
    {
        public string Header { get; set; }
        public ICommand Command { get; set; }
        public ObservableCollection<MenuItemVM> SubItems { get; set; }
    }

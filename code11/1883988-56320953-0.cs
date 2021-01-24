    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            items = new ObservableCollection<Item>();
            items.Add(new Item { Info = "01" });
            items.Add(new Item { Info = "02" });
            items.Add(new Item { Info = "03" });
            items.Add(new Item { Info = "04" });
            items.Add(new Item { Info = "05" });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public ObservableCollection<Item> items;
        public void Test()
        {
            foreach (var item in items)
            {
                item.Info += "X";
            }
        }
    
    }
    
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _info;
        public string Info
        {
            get
            {
                return _info;
            }
            set
            {
                _info = value;
                OnPropertyChanged();
            }
        }
    }

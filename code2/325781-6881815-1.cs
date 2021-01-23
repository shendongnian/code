    public class ItemTypeViewModel : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string category;
        public string Category
        {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged("Category");
                }
            }
        }
        public static ItemTypeViewModel FromModel(ItemType model)
        {
            var itemTypeViewModel = 
                new ItemTypeViewModel 
                {
                    Name = model.Name,
                    Category = categories[model.CategoryID].Name;
                };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var p = PropertyChanged;
            if (p != null)
            {
                p(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class ItemTypesViewModel : ObservableCollection<ItemTypesViewModel>
    {
        private ObservableCollection<ItemTypeViewModel> _collection;
        public ObservableCollection<ItemTypeViewModel> Collection
        {
            get { return _collection; }
            set
            {
                if (_collection != value)
                {
                    _collection = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Collection"));
                }
            }
        }
    }

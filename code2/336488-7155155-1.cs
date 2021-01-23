    public class ItemListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ObservableCollection<ItemViewModel> _items = new ObservableCollection<ItemViewModel>();
        public ItemListViewModel()
        {
            _items.CollectionChanged += OnItemsChanged;
        }
        public ICollection<ItemViewModel> Items { get { return _items; } }
        private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    e.NewItems.Cast<ItemViewModel>().ToList().ForEach(iv => iv.PropertyChanged += OnItemPropertyChanged);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    e.OldItems.Cast<ItemViewModel>().ToList().ForEach(iv => iv.PropertyChanged -= OnItemPropertyChanged);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("AverageValue"));
            }
        }
        public double AverageValue
        {
            get { return Items.Average(iv => iv.Value); }
        }
    }
    public class ItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Family { get; set; }
        private int m_Value;
        public int Value
        {
            get { return m_Value; }
            set
            {
                if (m_Value == value)
                    return;
                m_Value = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }
    }

    class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private ObservableCollection<object> m_Items;
        public ObservableCollection<object> Items
        {
            get { return m_Items; }
            set 
            { 
                m_Items = value; 
                m_Items.CollectionChanged += HandleItemsCollectionChanged; 
                PropertyChanged(this, new PropertyChangedEventArgs("Items");
            }
        }
        public int ProductCount
        {
            get
            {
                return Items == null 
                    ? 0 
                    : Items.OfType<ProductViewModel>().Count();
            }
        }
        private void HandleItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            PropertyChanged(this, new PropertyChangedEventArgs("ProductCount");
        }
    }

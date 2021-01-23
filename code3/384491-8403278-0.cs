        class BasketOfGoods : INotifyPropertyChanged
    {
        ObservableCollection<Good> contents = new ObservableCollection<Good>();
        public decimal Total
        {
            get { /* getter code */ }
            set { /*setter code */ }
        }
        public BasketOfGoods()
        {
            contents.CollectionChanged += contents_CollectionChanged;
        }
        void contents_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (var newGood in e.NewItems) ((Good)newGood).PropertyChanged += BasketOfGoods_PropertyChanged;
        }
        void BasketOfGoods_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Price") Total = contents.Select(x => x.Price).Sum();
        }
    }
    class Good : INotifyPropertyChanged
    {
        public decimal Price
        {
        {
            get { /* getter code */ }
            set { /*setter code */ }
        }
    }

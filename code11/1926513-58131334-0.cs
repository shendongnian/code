        void items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (ArukeresoShopMediator<T> item in e.OldItems)
                {
                    item.PropertyChanged -= item_PropertyChanged;
                }
            }
            if (e.NewItems != null)
            {
                foreach (ArukeresoShopMediator<T> item in e.NewItems)
                {
                    item.PropertyChanged += item_PropertyChanged;
                }
            }
        }
        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ...
        }
        public ArukeresoCriteriaTypeInspectorViewModelBase(T data)
            : base(data)
        {
            ...
            Shops = new ObservableCollection<ArukeresoShopMediator<T>>();
            Shops.CollectionChanged += items_CollectionChanged;
            ...

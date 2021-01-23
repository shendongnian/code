        public ObservableCollection<ItemViewModel> _items;
        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                return _items;
            }
            set
            {
                if (value != _items)
                {
                    _items = value;
                    NotifyPropertyChanged("Items");
                }
            }
        }
        private ItemViewModel _listBoxSelectedItem;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public ItemViewModel ListBoxSelectedItem
        {
            get
            {
                return _listBoxSelectedItem;
            }
            set
            {
                if (value != _listBoxSelectedItem)
                {
                    _listBoxSelectedItem = value;
                    NotifyPropertyChanged("ListBoxSelectedItem");
                }
            }
        }

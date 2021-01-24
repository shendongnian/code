    public ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                if(_items!=null && _items.Count>0)
                {
                    ItemsAvailable = true;
                }
            }
        }

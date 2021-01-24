    public class ItemsViewModel : INotifyPropertyChanged
    {
        private Item _selectingItem;
        private List<Item> _items;
        public Item SelectingItem
        {
            get { return this._selectingItem; }
            set
            {
                this._selectingItem = value;
                OnPropertyChanged(nameof(this.SelectingItem));
            }
        }
        public List<Item> ItemsCollection
        {
            get { return this._items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(ItemsCollection));
            }
        }
        public ICommand SelectRow { get; private set; }
        public ItemsViewModel()
        {
            this.ItemsCollection = new List<Item>();
            //Add default items
            this.ItemsCollection.Add(new Item("I001", "Text Book", 10));
            this.ItemsCollection.Add(new Item("I002", "Pencil", 20));
            this.ItemsCollection.Add(new Item("I003", "Bag", 15));
            this.SelectRow = new RelayCommand(this.SelectGridRow, o => true);
        }
        private void SelectGridRow(object param)
        {
            this.SelectingItem = this.ItemsCollection[0];
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

      class MyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        string itemMinPrice;
        public string ItemMinPrice
        {
            set
            {
                if (itemMinPrice != value)
                {
                    itemMinPrice = value;
                    OnPropertyChanged("ItemMinPrice");
                }
            }
            get
            {
                return itemMinPrice;
            }
        }
        string itemName;
        public string ItemName
        {
            set
            {
                if (itemName != value)
                {
                    itemName = value;
                    OnPropertyChanged("ItemName");
                }
            }
            get
            {
                return itemName;
            }
        }
    }

          public class DItem: INotifyPropertyChanged
    {
      
        string _itemName;
        public string itemName
        {
            set
            {
                if (_itemName != value)
                {
                    _itemName = value;
                    OnPropertyChanged("itemName");
                }
            }
            get
            {
                return _itemName;
            }
        }
        int _amt;
        public int amt
        {
            set
            {
                if (_amt != value)
                {
                    _amt = value;
                    OnPropertyChanged("amt");
                }
            }
            get
            {
                return _amt;
            }
        }
        string _amtType;
        public string amtType
        {
            set
            {
                if (_amtType != value)
                {
                    _amtType = value;
                    OnPropertyChanged("amtType");
                }
            }
            get
            {
                return _amtType;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

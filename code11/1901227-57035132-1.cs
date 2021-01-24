     class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Boolean _IsFocused;
        private String selectedItem;
        public ObservableCollection<String> Items { get; private set; }
        public String SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }      
        public Boolean IsFocused
        {
            get { return _IsFocused; }
            set
            {
                _IsFocused = value;
                RaisePropertyChanged("IsFocused");
            }
        }
        public ViewModel()
        {
            Items = new ObservableCollection<string>();
            Process();
        }
        private void Process()
        {
            Items.Clear();
            for (int i = 0; i < 100; i++)
            {
                Items.Add(i.ToString());
            }
            ChangeFocusedElement("2");
        }
        public void ChangeFocusedElement(string newElement)
        {
            var item = Items.FirstOrDefault(i => i == newElement);
            IsFocused = false;
            SelectedItem = item;
            IsFocused = true;
        }
        private void RaisePropertyChanged(String propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

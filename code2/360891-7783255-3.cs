        private string size;
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        private bool isSelected;
        public string Size
        {
            get { return size; }
            set
            {
                size= value;
                InvokePropertyChanged(new PropertyChangedEventArgs("size"));
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }
       
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("IsSelected"));
            }
        }
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }  

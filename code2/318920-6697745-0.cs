    class A : INotifyPropertyChanged
    {
        private int field1;
        public int Property1
        {
            get { return field1; }
            set
            {
                field1 = value;
                field2++;
                RaisePropertyChanged("Property1");
                RaisePropertyChanged("Property2");
            }
        }
        private int field2;
        public int Property2
        {
            get { return field2; }
            set
            {
                field2 = value;
                field1++;
                RaisePropertyChanged("Property1");
                RaisePropertyChanged("Property2");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

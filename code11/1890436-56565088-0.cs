    private class SoExample : INotifyPropertyChanged
    {
        private string _field1;
        public string Field1
        {
            get { return _field1; }
            set { _field1 = value; NotifyPropertyChanged(); }
        }
        private string _field2;
        public string Field2
        {
            get { return _field2; }
            set { _field2 = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

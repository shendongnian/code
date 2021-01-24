    public class Widget
    {
        private string _title1;
        public string Title1
        {
            get { return _title1; }
            set { _title1 = value; NotifyPropertyChanged(); }
        }
        private string _title2;
        public string Title2
        {
            get { return _title2; }
            set { _title2 = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

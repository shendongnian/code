    public class NewsData : INotifyPropertyChanged
    {
        private string _title;
        private string _message;
        private string _date;
        private string _author;
        public string InfoAuthor
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged("InfoAuthor");
            }
        }
        public string InfoDate
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("InfoDate");
            }
        }
        public string InfoMessage
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("InfoMessage");
            }
        }
        public string InfoTitle
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("InfoTitle");
            }
        }
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

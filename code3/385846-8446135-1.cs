    public class MyBool : INotifyPropertyChanged
    {
        private bool _isTrue;
        public bool IsTrue
        {
            get { return _isTrue; }
            set
            {
                if (_isTrue != value)
                {
                    _isTrue = value;
                    NotifyPropertyChanged("IsTrue");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

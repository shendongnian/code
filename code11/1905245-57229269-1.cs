     public class TestData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DataTable First
        {
            get { return _First; }
            set
            {
                _First = value;
                RaisePropertyChanged();
            }
        }
        private DataTable _First;
        public DataTable Second
        {
            get { return _Second; }
            set
            {
                _Second = value;
                RaisePropertyChanged();
            }
        }
        private DataTable _Second;
    }

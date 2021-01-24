    public class SelectedDataModel : INotifyPropertyChanged
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
                }
            }
        }
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                if (_Message != value)
                {
                    _Message = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Message"));
                }
            }
        }
        private bool _IsFavorite;
        public bool IsFavorite
        {
            get { return _IsFavorite; }
            set
            {
                if (_IsFavorite != value)
                {
                    _IsFavorite = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsFavorite"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

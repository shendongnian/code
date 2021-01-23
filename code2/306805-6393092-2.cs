    public class MyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private string _webAddress;
        public string WebAddress
        {
            get { return _webAddress; }
            set
            {
                if (value != _webAddress)
                {
                    _webAddress = value;
                    NotifyPropertyChanged("WebAddress");
                }
            }
        }
    }

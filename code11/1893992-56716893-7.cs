    class ProjViewModel : INotifyPropertyChanged
    {
        public ProjViewModel()
        {
        }
    
        private string _texttoshow;
        public string TextToShow
        {
            get { return _txttoshow; }
            set { _txttoshow= value; OnPropertyChanged("TxtToShow"); }
        }
    }

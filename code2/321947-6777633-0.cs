    public class MainWindowViewModel : ViewModelBase
    {
        private string _source;
        public string Source
        {
            get { return _source; }
            set
            {
                _source = value;
                OnPropertyChanged("Source");
                OnPropertyChanged("Destination");
            }
        }
        
        public string Destination
        {
            get { return "x" + _source + "x"; }
        }
        
    }

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            list = new ObservableCollection<string>();
            list.Add("string1");
            list.Add("string2");
            list.Add("string3");
        }
        public ObservableCollection<string> list { get; set; }
        private object _SelectedStats;
        public object SelectedStats
        {
            get { return _SelectedStats; }
            set
            {
                if (_SelectedStats != value)
                {
                    _SelectedStats = value;
                    RaisePropertyChanged("SelectedStats");
                }
            }
        }
    }

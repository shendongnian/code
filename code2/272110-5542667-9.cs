    public class MutexViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Text { get; set; }
        private bool _IsChecked;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                if (value != _IsChecked)
                {
                    _IsChecked = value;
                    OnPropertyChanged("IsChecked");
                }
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler h = PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class MutexesViewModel
    {
        public MutexesViewModel(IEnumerable<MutexViewModel>mutexes)
        {
            Mutexes = new ObservableCollection<MutexViewModel>(mutexes);
            foreach (var m in Mutexes)
            {
                m.PropertyChanged += MutexViewModel_PropertyChanged;
            }
        }
        private void MutexViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MutexViewModel m = (MutexViewModel) sender;
            if (e.PropertyName == "IsChecked" && m.IsChecked)
            {
                foreach(var other in Mutexes.Where(x => x != m))
                {
                    other.IsChecked = false;
                }
            }
        }
        public ObservableCollection<MutexViewModel> Mutexes { get; set; }
    }

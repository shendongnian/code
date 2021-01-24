        public  class MyViewModel : INotifyPropertyChanged
    {
  
        int _cidadeSelectedIndex=1;
        public int CidadeSelectedIndex
        {
            set
            {
                if (_cidadeSelectedIndex != value)
                {
                    _cidadeSelectedIndex = value;
                    OnPropertyChanged("CidadeSelectedIndex");
                }
            }
            get
            {
                return _cidadeSelectedIndex;
            }
        }
        public ObservableCollection<Local> locals { get; set; }
        public MyViewModel()
        {
            locals = new ObservableCollection<Local>();
            locals.Add(new Local() { cidade=  "xxx0"  , id=  0 });
            locals.Add(new Local() { cidade = "xxx1", id = 1 });
            locals.Add(new Local() { cidade = "xxx2", id = 2 });
            locals.Add(new Local() { cidade = "xxx3", id = 3 });
            locals.Add(new Local() { cidade = "xxx4", id = 4 });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

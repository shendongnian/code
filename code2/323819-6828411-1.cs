    public class MyViewModel : ViewModelBase
    {
        private int _min;
        public int Min
        {
            get { return _min; }
            set
            {
                _min = value;
                OnPropertyChanged("Min");
                OnPropertyChanged("ActualMin");
            }
        }
    
        private int _max;
        public int Max
        {
            get { return _max; }
            set
            {
                _max = value;
                OnPropertyChanged("Max");
                OnPropertyChanged("ActualMax");
            }
        }
        
        private bool _useMinMax;
        public bool UseMinMax
        {
            get { return _useMinMax; }
            set
            {
                _useMinMax = value;
                OnPropertyChanged("UseMinMax");
                OnPropertyChanged("ActualMin");
                OnPropertyChanged("ActualMax");
            }
        }
        
        public int ActualMin
        {
            get { return _useMinMax ? _min : 0; }
        }
        
        public int ActualMax
        {
            get { return _useMinMax ? _max : int.MaxValue; }
        }
    
    }

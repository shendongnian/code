    public class SomeDialogViewModel : ViewModelBase
    {
        public SomeDialogViewModel(List<ISelectedVal> values)
        {
            FullList = values;
        }
        public List<ISelectedVal> FullList { get; set; }
        private String _searchText = default(String);
        public String SearchText
        {
            get { return _searchText; }
            set
            {
                if (value != _searchText)
                {
                    _searchText = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _minInt = default(int);
        public int MinInt
        {
            get { return _minInt; }
            set
            {
                if (value != _minInt)
                {
                    _minInt = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _maxInt = default(int);
        public int MaxInt
        {
            get { return _maxInt; }
            set
            {
                if (value != _maxInt)
                {
                    _maxInt = value;
                    OnPropertyChanged();
                }
            }
        }
    }

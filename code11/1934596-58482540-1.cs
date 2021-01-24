    public partial class myCheckBox : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private string _NumBoards = "77";
        public string NumBoards
        {
            get
            {
                return _NumBoards;
            }
            set
            {
                _NumBoards = value;
                OnPropertyChanged("NumBoards");
            }
        }
        public myCheckBox()
        {
            InitializeComponent();
        }
    }

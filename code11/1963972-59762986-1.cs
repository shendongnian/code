     public partial class Page10 : ContentPage, INotifyPropertyChanged
    {
        private string _str;
        public string str
        {
            get { return _str; }
            set
            {
                _str = value;
                RaisePropertyChanged("str");
            }
        }
        public Page10()
        {
            InitializeComponent();
            str = "this is test";
            this.BindingContext = this;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public partial  class Page1 : ContentPage, INotifyPropertyChanged
    {
        private string _Url;
        public string Url
        {
            get { return _Url; }
            set
            {
                _Url = value;
                RaisePropertyChanged("Url");
            }
        }
		public Page1 ()
		{
			InitializeComponent ();
            Url = "a11.jpg";
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

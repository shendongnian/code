    public partial class Page10 : ContentPage, INotifyPropertyChanged
    {
        private string _text1;
        public string text1
        {
            get { return _text1; }
            set
            {
                _text1 = value;
                RaisePropertyChanged("text1");
            }
        }
        private string _text2;
        public string text2
        {
            get { return _text2; }
            set
            {
                _text2 = value;
                RaisePropertyChanged("text2");
            }
        }
        public Page10 ()
		{
			InitializeComponent ();
            text1 = "test1";
            text2 = "test2";
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

    public partial class Page17 : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<string> MyItemOptions { get; set; }
        private string _MyItem;
        public string MyItem
        {
            get { return _MyItem; }
            set
            {
                _MyItem = value;
                if(_MyItem== "Milk")
                {
                    IsMilkItem = true;
                }
                else
                {
                    IsMilkItem = false;
                }
            }
        }
        private bool _IsMilkItem;
        public bool IsMilkItem
        {
            get { return _IsMilkItem; }
            set
            {
                _IsMilkItem = value;
                RaisePropertyChanged("IsMilkItem");
            }
        }
        public Page17 ()
		{
			InitializeComponent ();
            MyItemOptions = new ObservableCollection<string>()
            {
                "item 1",
                "item 2",
                "item 3",
                "Milk"
            };
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

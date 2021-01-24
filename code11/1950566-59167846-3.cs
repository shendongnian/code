    public ObservableCollection<string> MyItemOptions { get; set; }
        private string _MyItem;
        public string MyItem
        {
            get { return _MyItem; }
            set
            {
                _MyItem = value;
               
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

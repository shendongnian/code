     public DetailPage(AdLogEntry detail)
     {
            InitializeComponent();
            this.BindingContext = new AdDetailViewModel(adDetail);
     }

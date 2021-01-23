         public Page1()
        {
            InitializeComponent();
        
            if (SessionManager.Exist("PageViewModel"))
            {
                this.DataContext = SessionManager.Get<Page1ViewModel>("PageViewModel");
            }
            else
                this.DataContext = new PageViewModel();
        }

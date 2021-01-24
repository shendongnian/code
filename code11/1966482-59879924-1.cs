        public App()
        {
            InitializeComponent();
            Instance = this;
            MainPage = new ContentPage { Title = "Test" };
            RegisterPages();
            RegisterModals();
            ModalPopping += ModalService.ModalPopping;
        }
    
        protected override void OnStart()
        {
            NavigationService.SetRoot(new Test());
        }

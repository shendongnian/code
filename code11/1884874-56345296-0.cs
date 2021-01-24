        public SessionViewModel ViewModel { get; set; }
        public SessionView() => this.InitializeComponent();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var prms = (WindowParameters)e.Parameter;
            prms.Frame = this.Frame;
            this.ViewModel = new SessionViewModel(prms);
            this.DataContext = ViewModel;
            this.ViewModel.LoadFullModel();
        }
